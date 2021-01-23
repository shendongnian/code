    List<object> list = new List<object>();
    list.Add("foo");
    list.Add(5);
    foreach(object o in list) 
    {
        Console.WriteLine(o.ToString());
    }
