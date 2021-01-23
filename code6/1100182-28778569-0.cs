        String str = "<a href=\"/Forums2008/forumPage.aspx?forumId=317\" title=\"הנקה\">הנקה</a>"; // <== Assume this is passing string. Yes unusual scape sequence are added 
        int splitStart = str.IndexOf("title="); 
        int splitEnd = str.LastIndexOf("</a>");
        String extracted = str.Substring(splitStart, splitEnd - splitStart);
        String[] splitted = extracted.Split('"');
        Console.WriteLine(splitted[1]);
