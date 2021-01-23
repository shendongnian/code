     List<String> nameList = new List<String>();
                var NAME= XElement.Parse(xml);
                if (NAME.Attribute("name") != null )
                {
                    nameList.Add(new String{ name = profile.Attribute("name").Value });
                }
