     protected void Page_Load(object sender, EventArgs e)
     {
          if (Session["name"] != null)
          {
               lblName.Text = Session["name"].ToString();
          }
     }
