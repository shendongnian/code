               foreach (HtmlNode bodyNode in doc.DocumentNode.SelectNodes("//body"))
                {
                    string newImg = "new-value.png";
                    if (bodyNode.Attributes.Contains("style") && bodyNode.Attributes["style"].Value.Contains("background-image:url"))
                    {                     
                        string style = bodyNode.Attributes["style"].Value;
                        string oldImg = Regex.Match(style, @"(?<=\().+?(?=\))").Value;
                        string oldStyle = bodyNode.Attributes["style"].Value;
                        string newStyle = oldStyle.Replace(oldImg, newImg);
    
                        bodyNode.Attributes.Remove("style");
                        bodyNode.Attributes.Add("style", newStyle);
                    }
                    
                }
