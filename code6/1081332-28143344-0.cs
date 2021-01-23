    List<object> l = new List<object>();
    l.Add(i1);
    l.Add(i2);
    // and so on...
    
    
    foreach(var i in l)
    {
       Console.WriteLine(i.GetType());
    }
