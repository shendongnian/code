    XElement root = XElement.Parse(strSerializedoutput);
                        Dictionary<int, Pair> list = root.Descendants("item").ToDictionary(x => (int)x.Attribute("id"), x =>
                        {
                            var pId = x.Parent.Attribute("id");
                            var depthLevel = x.Attribute("level");
                            if (pId == null)
                            {
                                return new Pair { parentID = 0, level = (int)depthLevel };
                            }
                            else
                            {
                                return new Pair { parentID = (int)pId, level = (int)depthLevel };
                            }
                        });
