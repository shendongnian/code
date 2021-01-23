    internal class Program
    {
        private static void Main()
        {
            var c = new Category();
            c.Name = "Some category";
            var categoryRepository = new CategoryRepository();
            categoryRepository.Add(c);
            var a = new Article();
            a.Category = c;
            a.Content = "Some content";
            a.Title = "Some title";
            var repository = new ArticleRepository();
            // give the static checker a helping hand
            // we don't want to proceed if a is not valid anyway
            if (!a.IsValid)
            {
                throw new InvalidOperationException("Hard to check statically");
                // alternatively, do "Contract.Assume(a.IsValid)"
            }
            repository.Add(a);
            Console.WriteLine("Done");
        }
    }
    public class Category
    {
        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
        }
        private string _name;
        public string Name {
            get { return _name; }
            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value));
                Contract.Ensures(IsValid);
                _name = value;
                _isValid = true;
            }
        }
        [ContractInvariantMethod]
        void Invariant()
        {
            Contract.Invariant(!_isValid || !string.IsNullOrEmpty(_name));
        }
    }
    public class Article
    {
        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value));
                _title = value;
                CheckIsValid();
            }
        }
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value));
                _content = value;
                CheckIsValid();
            }
        }
        private Category _category;
        public Category Category {
            get { return _category; }
            set
            {
                Contract.Requires(value != null);
                Contract.Requires(value.IsValid);
                _category = value;
                CheckIsValid();
            }
        }
        private void CheckIsValid()
        {
            if (!_isValid)
            {
                if (!string.IsNullOrEmpty(_title) &&
                    !string.IsNullOrEmpty(_content) &&
                    _category != null &&
                    _category.IsValid)
                {
                    _isValid = true;
                }
            }
        }
        [ContractInvariantMethod]
        void Invariant()
        {
            Contract.Invariant(
                !_isValid ||
                    (!string.IsNullOrEmpty(_title) &&
                    !string.IsNullOrEmpty(_content) &&
                    _category != null &&
                    _category.IsValid));
        }
    }
    public class CategoryRepository
    {
        private readonly List<Category> _categories = new List<Category>(); 
        public void Add(Category category)
        {
            Contract.Requires(category != null);
            Contract.Requires(category.IsValid);
            Contract.Ensures(category.IsValid);
            _categories.Add(category);
        }
    }
    public class ArticleRepository
    {
        private readonly List<Article> _articles = new List<Article>();
        public void Add(Article article)
        {
            Contract.Requires(article != null);
            Contract.Requires(article.IsValid);
            Contract.Ensures(article.IsValid);
            _articles.Add(article);
        }
    }
