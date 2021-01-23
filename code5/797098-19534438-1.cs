       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RepDetails.DataSource = GetData();
                RepDetails.DataBind();
            }
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Repeater repeater = ((ImageButton)sender).NamingContainer.FindControl("SportsProps") as Repeater;
            Label catLabel = ((ImageButton)sender).NamingContainer.FindControl("lblSubject") as Label;
            repeater.DataSource = GetDataDetail(catLabel.Text);
            repeater.DataBind();
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //do something to hide the 
        }
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("category", typeof(string));
            dt.Rows.Add("1 ", "Basketball");
            dt.Rows.Add("2 ", "Football");
            dt.Rows.Add("3 ", "Soccer");
            return dt;
        }
        private DataTable GetDataDetail(string category)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Rows.Add("Bat");
            dt.Rows.Add("Ball");
            dt.Rows.Add("Stump");
            return dt;
        }
