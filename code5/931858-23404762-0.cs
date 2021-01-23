    protected List<TableRow> _rows
    {
      get
      {
        List<TableRow> list = (List<TableRow>) ViewState["myRows"];
        if (list != null)
           return list;
        else
           return new List<TableRow>;
      }
      set
      {
        ViewState["myRows"] = value;
      }
    }
    
    private override void DataBind()
    {
        tblLanguages.Rows = _rows;
    
    }
