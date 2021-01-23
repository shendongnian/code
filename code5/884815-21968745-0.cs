        var links = htmlDoc.DocumentNode.SelectNodes("//*[@id='First']/input[@value]");
        if (links != null)
        {
            foreach (var link in links)
            {
                string value = link.Attributes["value"].Value;
                string name = null;
                var span = link.SelectSingleNode("following-sibling::span");
                if (span != null)
                {
                    name = span.InnerText;
                }
                Console.WriteLine(name + " - " + value);
            }
        }
