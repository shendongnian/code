    public void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ArrayList idList = new ArrayList();
            idList.Add(System.IO.Path.GetFileName(FileName));
            Session["MyArrayList"] = idList;
        }          
    }
