     if (IE.Exists<IE>(Find.By("Title", FirstLinkText)))
     {
         mainPage = Browser.AttachTo<IE>(Find.ByTitle(new Regex(FirstLinkText))); 
     }
     else
     {
         browser = new IE();
     }
