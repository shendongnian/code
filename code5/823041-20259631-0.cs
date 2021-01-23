     public T Deserialize<T>(string entity)
        {
            var obj = Activator.CreateInstance<T>();
            var stringProps = entity.Split(',');
            **var str = deletespace(stringProps);**
            var objProps = obj.GetType().GetProperties();
            var propIndex = 0;
            for (int i = 0; i < str.Count; i++)
            {
                try
                {
                    if (objProps[propIndex].PropertyType.FullName == "System.String")
                    {
                        objProps[propIndex].SetValue(obj, stringProps[i], null);
                    }
                    else if (objProps[propIndex].PropertyType.FullName == "System.Int32")
                    {
                        objProps[propIndex].SetValue(obj, Convert.ToInt32(stringProps[i]), null);
                    }
                    else if (objProps[propIndex].PropertyType.FullName == "System.DateTime")
                    {
                        var cultureInfo = new CultureInfo("fa-IR");
                        DateTime dateTime = Convert.ToDateTime(stringProps[i], cultureInfo);
                        objProps[propIndex].SetValue(obj, dateTime, null);
                    }
                    else if (objProps[propIndex].PropertyType.FullName == "System.Boolean")
                    {
                        objProps[propIndex].SetValue(obj, Convert.ToBoolean(stringProps[i]), null);
                    }
                    else
                    {
                        i--;
                    }
                    propIndex++;
                }
                catch (IndexOutOfRangeException)
                {
                    Debug.WriteLine("Index Out Of range");
                }
            }
            return obj;
        }
        **private List<string> deletespace(string[] spaceStrings)
        {
            var lststr = new List<string>();
            for (int i = 0; i < spaceStrings.Length; i++)
            {
                if (spaceStrings[i] != "")
                {
                    lststr.Add(spaceStrings[i]);
                }
            }
            return lststr;
        }**
