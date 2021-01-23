        public Form1()
        {
            InitializeComponent();
    
            UserControl1 userControl = new UserControl1();
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(userControl);
                       
        }
