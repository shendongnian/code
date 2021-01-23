    public class ManageViewModel
    {
        public ManageViewModel()
        {
            LocalPassword = new LocalPasswordModel();
            LocalEmail = new LocalEmailModel();
        }
        public LocalPasswordModel LocalPassword { get; set; }
        public LocalEmailModel LocalEmail { get; set; }
    }
