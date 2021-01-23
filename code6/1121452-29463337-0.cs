    // loop over innerhtml and process
    var thenode = document.DocumentNode.Descendants().Where(n => n.Name == "body").FirstOrDefault();
    if (thenode != null)
    {
        // InnerHtml replaces <br /> with <br>
        String[] strings = thenode.InnerHtml.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (String str in strings)
        {
            String lstr = str.Trim();
            if (lstr != String.Empty && !lstr.StartsWith("<"))
            {
                // do processing
                String loutput = Processing(lstr);
                thenode.InnerHtml = thenode.InnerHtml.Replace(lstr, loutput);
            }
        }
    }
