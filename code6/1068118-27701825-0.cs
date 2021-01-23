        List<string> UsaCities = new List<string>();
        List<string> IndiaCities = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
   
                UsaCities.Add("newyork");
                UsaCities.Add("new jersy");
                UsaCities.Add("texas");
                IndiaCities.Add("hyderabad");
                IndiaCities.Add("calcutta");
                IndiaCities.Add("chennai");
    
                DropDownList1.DataSource = UsaCities;
                DropDownList1.DataBind();
            }
            
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                DropDownList2.DataSource = UsaCities;
                DropDownList2.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                DropDownList2.DataSource = IndiaCities;
                DropDownList2.DataBind();
            }
        }
