    public class DocProductViewModel
    {
        private IDocProductRepository repository;
        public DocProductViewModel(IDocProductRepository docProductRepository)
            {
                this.repositoryMain = docMainRepository;
            }
        public IList<DocProduct> DocProductList
        {
            get
            {
               return repository.GetList();
            }
        }
    }
