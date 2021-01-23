    public void AddXElementAttributesToThisClass(XElement xe)
            {
                ExpandoObject obj = new ExpandoObject();
                foreach (var attribute in xe.Attributes())
                {
                     (obj as IDictionary<string, object>)[attribute.Name.ToString()] = attribute.Value.Trim();
                }
                var dynamicDictionary = obj as IDictionary<string, object>;
                foreach (var property in this.GetType().GetProperties())
                {
                    var propName = property.Name;
                    var value = property.GetValue(this, null);
                    if (dynamicDictionary.ContainsKey(propName) && value != dynamicDictionary[propName])
                    {
                        var foundXmlObj= dynamicDictionary[propName];
                        property.SetValue(this, foundXmlObj);
                    }
                }
            }
