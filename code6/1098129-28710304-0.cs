    if (prop.PropertyType.IsArray )
                            {
                                
                                ArrayList arrLst = new ArrayList();
                                
                                var arrayElements = childNodeprop.Elements(prop.Name);
                                
                                foreach(XElement element in arrayElements )
                                {
                                    arrLst.Add(element.Value);
                                }
                                var  BaseElementType= prop.PropertyType.GetElementType();
                                prop.SetValue(obj, arrLst.ToArray(BaseElementType), null);
                               
                               
                            }
    and it works..
