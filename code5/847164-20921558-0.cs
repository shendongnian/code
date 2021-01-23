    Dictionary<String, List<Object>> Data = new Dictionary<String, List<Object>>();
    
    Data["MyUser"] = new List<Object>();
    Data["MyUser"].Add(MyDBObject);
    
    var obj = Data["MyUser"].Find(x => x.MyKey == "MyKeyObject");
    var t = obj.GetType();
    var dta = (MyDBObject)obj;
    
    foreach (var db in Data)
    {
       if (db.Key == "MyUser")
          db.Value.Find(x => x.Name == "MyName");
    }
