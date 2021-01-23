        public Form2()
        {
            InitializeComponent();
        }
    
  
        public Action yourAction {get; set;}
        private void callMethod_Click(object sender, EventArgs e)
        {
            Action instance = yourAction;
            if(instance != null)
                instance();
        }
