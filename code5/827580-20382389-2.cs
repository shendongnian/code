    public class Module
    {
        public int Module_ID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleAbbreviation { get; set; }
        public bool ModuleDisabled { get; set; }
        public DateTime ModuleLicenseDate { get; set; }
    }
    public class UserModule
    {
        public int Module_ID { get; set; }
        public int User_Module_Access { get; set; }
    }
    public class User
    {
        public string UserName { get; set; }
        public ObservableCollection<UserModule> UserModules = new ObservableCollection<UserModule>();
    }
