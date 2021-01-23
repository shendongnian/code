    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            Questions = Enumerable.Range(1, 10)
                .Select(i => new Question
                {
                    Name = "Question " + i,
                    MainOptions = Enumerable.Range(1, 5)
                        .Select(j => new MainOption {Name = "Option " + i})
                        .ToList()
                })
                .ToList();
        }
        public List<Question> Questions { get; private set; }
    }
    public class Question
    {
        public string Name { get; set; }
        public List<MainOption> MainOptions { get; set; }
        public bool IsNodeExpanded { get; set; }
        public Question()
        {
            IsNodeExpanded = true;
            MainOptions = new List<MainOption>();
        }
    }
