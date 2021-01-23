        ContentManager contentManager = new ContentManager(ApiAccessMode.Admin);
        Ektron.Cms.ContentData contentData = new Ektron.Cms.ContentData();
        contentData.Title = "title 011";
        contentData.Html = "<root><EventName>Change1...</EventName>" +
                         "<EventDescription>Description Test</EventDescription>" +
                         "<EventDate>2014-10-30</EventDate>" +
                         "</root>";
        contentData.ContType = 1;
        contentData.Comment = "Automatically generated from a script.";
        contentData.FolderId = 86; //folder id to save you smart data
        contentData.IsPublished = true;
        contentData.IsSearchable = true;
        contentData.LanguageId = 1033;
        contentData.XmlInheritedFrom = 86; //folder id to save you smart data
        Ektron.Cms.XmlConfigData xcd = new Ektron.Cms.XmlConfigData();
        xcd.Id = 7; //SmartForm ID
        contentData.XmlConfiguration = xcd;
        contentManager.Add(contentData);
