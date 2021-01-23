            protected void Page_Load(object sender, EventArgs e)
            {
                btnFill.Click += new EventHandler(btnFill_Click);
            }
    
            void btnFill_Click(object sender, EventArgs e)
            {
                txtSalary.Text = "200";
            }
