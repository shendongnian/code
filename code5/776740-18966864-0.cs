        public Form1()
        {
            InitializeComponent();
            rbOne.Click += new EventHandler(radioButton_Click);
            rbTwo.Click += new EventHandler(radioButton_Click);
        }
        public void radioButton_Click(object sender, EventArgs e)
        {
            status = rbOne.Checked ? rbOne.Text : rbTwo.Text;
    }
