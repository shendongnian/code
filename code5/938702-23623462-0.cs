    string path = AppDomain.CurrentDomain.BaseDirectory;
        System.IO.StreamReader myreader = new System.IO.StreamReader(path +  "MyTest\\randerhtml.html");
        string s = myreader.ReadToEnd();
        myreader.Close();
        @(new HtmlString(s))
