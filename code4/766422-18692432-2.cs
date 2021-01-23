    [WebMethod]
    public static List<Myclass> void upnl_Load( string FirstDropDownValue)
    {
      if (FirstDropDownValue != "-1")
      {
        return objMngr.GetData(FirstDropDownValue);
      }
      
      upnl.Update();
    }
