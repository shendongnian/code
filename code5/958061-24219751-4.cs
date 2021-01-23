    List<string> listOfTitles = new List<string>();
    foreach (var link in bTags)
    {
        //NOTE!: You want to set the o.InnerText to string, not the resulting list. (ive done that in this example)
        IEnumerable<string> linkTitles = htmlDocument.DocumentNode.SelectNodes("//div[@id='view-subject']//h1").Select(o => o.InnerText.ToString());
    
        Job currentJob = new Job()
        {
        	JobTitle = linkTitles.ToList();
        };
    }
