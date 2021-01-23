    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Items> dataList = new List<Items>();
            dataList.Add(new Items("A", 10));
            dataList.Add(new Items("B", 20));
            dataList.Add(new Items("C", 30));
            JavaScriptSerializer jss = new JavaScriptSerializer();
            this.ChartData.Value = jss.Serialize(dataList);
        }
    }
