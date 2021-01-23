        private System.Collections.Generic.List<string> championsList;
        private System.Collections.Generic.List<string> rolesList;
        
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            // loadList uses these lists so they should be initialized before the call to loadList to avoid a NullReferenceException.
            championsList = new System.Collections.Generic.List<string>();
            rolesList = new System.Collections.Generic.List<string>();
            loadList(listFile);
        }
