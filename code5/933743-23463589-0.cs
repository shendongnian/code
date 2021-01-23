    public class MainVM : ViewModelBase
    {
        public ObservableCollection<PersonVM> People { get; set; }
    }
    public class PersonVM : ViewModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ObservableCollection<SkillVM> Skills { get; set; }
    }
    public class SkillVM : ViewModelBase
    {
        public string Name { get; set; }
        public bool IsOn { get; set; }
    }
