                    String content = "Your Html page source as string";
                    HtmlNode.ElementsFlags.Remove("form");
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(content);
                    // Pass the name of the tag you want to remove 
                    DeleteTagByName("tagname",doc);
                    public void DeleteTagByName(string name, HtmlDocument HtmlDocument)
                     {
                         HtmlDocument.DocumentNode.SelectSingleNode("//input[@name='" + name + "']").Remove();
            
                    } 
