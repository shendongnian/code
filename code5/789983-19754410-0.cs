                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(inputHtml);
                var elementsWithStyleAttribute = doc.DocumentNode.SelectNodes(string.Concat("//", tagName));
                if (null == elementsWithStyleAttribute)
                {
                    return inputHtml;
                }
                foreach (var element in elementsWithStyleAttribute)
                {
                    var classElement = element.GetAttributeValue("class", null);
                    if (!string.IsNullOrWhiteSpace(classElement))
                    {
                        // Remove class attribute.
                        element.Attributes["class"].Remove();
                    }
                    var styles = element.GetAttributeValue("style", null);
                    if (!string.IsNullOrWhiteSpace(styles)) //&& (styles.ToUpper().Contains("FONT-FAMILY:") || styles.ToUpper().Contains("FONT-SIZE:")))
                    {
                        element.Attributes["style"].Remove();
                        string[] splitter = { ";" };
                        string[] styleClasses = styles.Split(splitter, StringSplitOptions.None);
                        StringBuilder sbStyles = new StringBuilder("font-family:Arial; font-size:10pt;");
                        if (null != styleClasses && styleClasses.Length > 0)
                        {
                            foreach (var item in styleClasses)
                            {
                                if (!string.IsNullOrWhiteSpace(item) && !item.ToUpper().Contains("FONT-FAMILY:")
                                    && !item.ToUpper().Contains("FONT-SIZE:") && !item.ToUpper().Contains("FONT:"))
                                {
                                    // Add existing styles except font size and font family styles.
                                    sbStyles.Append(item.Trim());
                                    sbStyles.Append(";");
                                }
                            }
                        }
                        element.SetAttributeValue("style", sbStyles.ToString());
                    }
                    else
                    {
                        element.SetAttributeValue("style", "font-family:Arial; font-size:10pt;");
                    }
                }
                return doc.DocumentNode.InnerHtml;
