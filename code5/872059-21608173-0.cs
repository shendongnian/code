            protected void Page_Load(object sender, EventArgs e)
            {
                Button1.Click += new EventHandler(Button1_Click);
            }
    
            void Button1_Click(object sender, EventArgs e)
            {
                TextBox1.Text = "Hello";
            }
