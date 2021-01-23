    protected void Page_Load(object sender, EventArgs e)
        {
     string Ques = Convert.ToString(Session["LBQ"]);
            Questionlabel.Text = Ques;      
        }
