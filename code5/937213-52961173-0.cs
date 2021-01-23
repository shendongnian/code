     List<ModelName> ModelList = new List<ModelName>();
     var regex = new Regex(@"\d");
     foreach(var item in ModelList.ToList())
                    {
                        if (regex.IsMatch(item.PropertyName))
                        {
                            ModelList.RemoveAll(t => t.PropertyName== item.PropertyName);
                        }
                    }
     return ModelList;
