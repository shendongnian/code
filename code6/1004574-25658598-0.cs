           if (IE.Exists<IE>(Find.By("Title", FirstLinkText)))
            {
                mainPage = Browser.AttachTo<IE>(Find.ByTitle(title => title.Equals(FirstLinkText));
            }
            else
            {
                browser = new IE();
            }
