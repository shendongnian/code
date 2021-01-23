     public lineThreePage()
        {
            InitializeComponent();
            BindData();
        }
        private void BindData()
        {
            var data = IsolatedStorageManager.FeedItemViewModel;
            if (data != null)
            {
                //Bind the data to a text box in your xaml named "txtDescription"
                txtDescription.Text = data.LineTwo;
            }
        }
