    public partial class CustomerForm: Form
    {
        private object instance;
        public CustomerForm()
        {
            InitializeComponent();
            SetData(BLL.CreateNewEmptyObject());
        }
        public CustomerForm(object details)
            : this()
        {
            SetData(details);
        }
        public void SetData(object details)
        {
            instance = details;
            //bind the details to controls 
        }
        private void Save()
        {
            BLL.Save(instance);
        }
       public bool EnableEdit {get{... 
    }
