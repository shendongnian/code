    protected void Page_Load(object sender, EventArgs e)
        {
          //  lblEM_Title.Text = Session["Title"].ToString();
            if (Session["firstname"] != null)
            {
                EM_ddlTitle.Text = Session["title"].ToString();
                lblEM_FirstName.Text = Session["firstname"].ToString();
                lblEM_LastName.Text = Session["firstname"].ToString();                
            }
            else {
                Label2.Text = "ERROR";
            }
