    IList<string> propertyList = new List<string>();
                    var properties = typeof(Input0Buffer).GetProperties();
                    foreach (var property in properties)
                    {
                        if (!property.Name.EndsWith("_IsNull"))
                            propertyList.Add(property.Name);
                    }
