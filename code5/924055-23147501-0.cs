            List<string> Names;
            
            public Form1()
            {
                InitializeComponent();
                Names = new List<string>();
                Names.Add("Sara");
                Names.Add("Bill");
                Names.Add("Martin");
                Names.Add("Susan");
                Names.Add("Don");
                listBox1.DataSource = Names;
               
            }
            private void button1_Click(object sender, EventArgs e)
            {
                if (listBox1.SelectedItem == "Sara")
                {
                    Names.Remove("Sara");
                }
                //To Insert a new Name at specific index say 1st
                Names.Insert(1, "Sample");
            }
