        public Form1()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            UserControl1 userControl = new UserControl1();
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(userControl);
                       
        }
