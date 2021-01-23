    public partial class UserForm : Form
    {
        public enum UserFormMode {Edit, Add, Delete};
        private UserFormMode mode;
        public UserForm()
        {
            InitializeComponent();
        }
     
        public UserFormMode Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                switch (mode)
                {
                    case UserFormMode.Add:
                    // adjust your form
                    break;
                    case UserFormMode.Delete:
                    // adjust your form
                    break;
                    case UserFormMode.Edit:
                    // adjust your form
                    break;
                }
            }
        }
    }
