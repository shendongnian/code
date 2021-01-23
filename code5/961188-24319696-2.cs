        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listData = new List<string>();
                listData.Add("Blue");
                listData.Add("Blue");
                listData.Add("Blue");
            }
            myRepeater.DataSource = listData;
            myRepeater.DataBind();
        }
