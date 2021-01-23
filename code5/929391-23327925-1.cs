           protected void Page_Load(object sender, EventArgs e)
           {
            string email = (string)(Session["email"]);
            string date = (string)(Session["date"]);
            string time = (string)(Session["time"]);
            string name = (string)(Session["name"]);
            TextBox1.Text = email;
            TextBox2.Text = date;
            TextBox3.Text = time;
            TextBox4.Text = name;
        }
