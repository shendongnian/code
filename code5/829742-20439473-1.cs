        public Form1 ()
        {
            InitializeComponent();
            BindComboList();
        }
        private void BindComboList()
        {
            var values = Enum.GetValues(typeof(AccountType));
            foreach (var item in values)
            {
                cmbAccountType.Items.Add(item);
            }
        }
