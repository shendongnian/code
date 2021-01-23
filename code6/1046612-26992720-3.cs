        string[] allowedAttributes = { "STYLE", "SRC" };
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//node()"))
            {
                List<HtmlAttribute> attributesToRemove = new List<HtmlAttribute>();
                foreach (HtmlAttribute att in node.Attributes)
                {
                    if (!allowedAttributes.Contains(att.Name.ToUpper())) attributesToRemove.Add(att);
                    else
                    {
                         string newAttrib = string.Empty;
                        //do string manipulation based on your checking accepted properties
                        //one way would be to split the attribute.Value by a semicolon and do a
                        //String.Contains() on each one, not appending those that don't match. Maybe
                        //use a StringBuilder instead too
                        att.Value = newAttrib;
                    }
                }
                foreach (HtmlAttribute attribute in attributesToRemove)
                {
                    node.Attributes.Remove(attribute);
                }
            }
