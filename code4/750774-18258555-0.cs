    [WebGet(UriTemplate = "json/test")]
    public Stream testJSON()
    {
        return test(outputType.JSON);
    }
    [WebGet(UriTemplate = "xml/test")]
    public Stream testXML()
    {
        return test(outputType.XML);
    }
    ...
    private Stream test(outputType ot)
    {
       using (DataTable dt = new DataTable("test"))
       {
          //build dummy datatable
          dt.Columns.Add("col1");
          dt.Rows.Add(dt.NewRow());
          dt.Rows[0]["col1"] = "asdf";
    
          //serialize results
          return _m.serialize(outputType, dt);
       }
    }
