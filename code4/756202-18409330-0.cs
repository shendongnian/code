      protected void Page_Load(object sender, EventArgs e)
      {
            //Label1.Text = x.ToString();
            Session["x"] = x;
      }
    
      protected void Button1_Click(object sender, EventArgs e)
      {
            x = Session["x"];
            x++;
            Label1.Text = x.ToString();
      }
