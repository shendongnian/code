    class MX
    {
        public string BatchNo { get; set; }
        public string SpecimenID { get; set; }
        //and so on
        static public List<MX> Arr = new List<MX>();
    }
    protected void Page_Load(object sender, EventArgs e)
    {        
        XDocument doc = XDocument.Load(Server.MapPath("~/xml/a.xml"));
        List<string> ListBatchNo = new List<string>();
        foreach (var node in doc.Descendants("BatchNo."))
        {
            ListBatchNo.Add(node.Value);
        }
        List<string> ListSpecimenID = new List<string>();
        foreach (var node in doc.Descendants("SpecimenID"))
        {
            ListSpecimenID.Add(node.Value);
        }
        MX.Arr.Clear();
        for (int i = 0; i < ListBatchNo.Count; i++)
        {
            MX obj = new MX();
            obj.BatchNo = ListBatchNo[i];
            obj.SpecimenID = ListSpecimenID[i];
            MX.Arr.Add(obj);
        }
        GridView2.DataSource = MX.Arr;
        GridView2.DataBind();
    }
