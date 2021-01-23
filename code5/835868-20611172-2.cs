    protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Session["name"].ToString();
            TextBox2.Text = Session["adr"].ToString();
            TextBox3.Text = Session["con"].ToString();
            TextBox4.Text = Session["email"].ToString();
    
    
            Label1.Text = Session["rom"].ToString();
            Label5.Text = Session["prc"].ToString();
            Label4.Text = Session["room"].ToString();
    
            string strImageUrls = Convert.ToString(Session["img"]);
            string[] arrImageUrls = strImageUrls.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrImageUrls != null && arrImageUrls.Length > 0)
            {
                foreach (string strImageURL in arrImageUrls)
                {
                    //DO your image binding here like
                    //Image1.ImageUrl = strImageURL ;
                }
            }
        }
