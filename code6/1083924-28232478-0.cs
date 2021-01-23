    foreach (XElement node in doc.Descendants("category").Elements())
            {
                if (node.Name.LocalName.Equals("titre"))
                {
                    layout.Records.Add(new XMLRecord()
                    {
                        Type = "Titre",
                        Contenu = node.Value
                    });
                }
                //This check requires here because at every item you won't get NextNode null except last one.
                else if (node.Name.LocalName.Equals("item") && node.NextNode == null)
                {
                    layout.Records.Add(new XMLRecord()
                    {
                        Type = "Item",
                        Contenu = node.Value
                    });
                    layout.Records.Add(new XMLRecord()
                    {
                        Type = "Separateur",
                        Contenu = ""
                    });
                }
                else if (node.Name.LocalName.Equals("item"))
                {
                    layout.Records.Add(new XMLRecord()
                    {
                        Type = "Item",
                        Contenu = node.Value
                    });
                }
            }
            return layout.Records;
