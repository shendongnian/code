    Dictionary<string, object> theData= new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(jsonString);
    System.Collections.ArrayList dData= (System.Collections.ArrayList)theData["DData"];
    foreach (Dictionary<string, object> data in dData)
    {
     string date = (string)data["Date"];
     Dictionary<string, object> cZeroNode = (Dictionary<string, object>)data["C0"];
     string d = (string)cZeroNode["D"];
     string id = (string)cZeroNode["Id"];
    }
