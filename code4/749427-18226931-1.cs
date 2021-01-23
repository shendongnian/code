        string notAllowed1 = @"//";
        string notAllowed2 = @"/*";
        var contains = false;
        foreach(string line in rtb_JS.Lines)
        {
           if (line.Text.StartsWith(notAllowed2) || !line.Text.StartsWith(notAllowed1))
           {
             contains = true;
             break
           }
       }
    //else do nothing
