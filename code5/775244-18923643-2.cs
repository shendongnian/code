    public void Page_Load(object sender, EventArgs e)
    {
    		ArrayList idList = (ArrayList)Session["MyArrayList"];	
    		idList.Add(System.IO.Path.GetFileName(FileName));
    		Session["MyArrayList"] = idList;                 
    }
