    List<OleDbParameter> parameters = new List<OleDbParameter>();
    parameters.Add(new OleDbParameter()) 
    {
          ParameterName = "@p1", OleDbType= OleDbType.VarWChar, Value = o.ID_Observer
    }
    parameters.Add(new OleDbParameter()) 
    {
          ParameterName = "@p2", OleDbType= OleDbType.VarWChar, Value = o.Lat
    }
    parameters.Add(new OleDbParameter()) 
    {
          ParameterName = "@p3", OleDbType= OleDbType.VarWChar, Value = o.Long
    }
    parameters.Add(new OleDbParameter()) 
    {
          ParameterName = "@p4", OleDbType= OleDbType.VarWChar, Value = o.Azimuth
    }
    DataBaseIkuns.Instance.InsertToDB(
        DictionaryUtilsDB.dictioneary[DictionaryUtilsDB.CommendTypes.AddObserver], parameters);
