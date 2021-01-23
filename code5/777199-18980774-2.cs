    var s = new StringBuilder();
    var s1 = new StringBuilder();
    string[] _d = new string [10];
    s.AppendFormat("\"{0}\",\"{1}",
                   "test1",
                   "test2"
                  );
    for(var i = 0; i < 10 ; i++)
    {
         s1.Append(",\" Loop {"+i+"}\"");
        _d[i] = i.ToString();
    }
    s.AppendFormat(s1.ToString(), _d);
