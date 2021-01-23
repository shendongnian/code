    string strTestline = "This is /Test/. You can /test2/";
    string[] strarray = strTestline.Split(new char[] { '/' });
    
    foreach (string block in strarray)
    {
         Console.WriteLine(block);
    }
