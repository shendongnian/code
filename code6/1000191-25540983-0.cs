     private void CreateXElemetsOfClass(System.Type typeOfClass, string TableName, dynamic objData, string p_mainElementName, string MachineID)
            {
                try
                {
                    if (objData != null && objData.Count > 0)
                    {
                        System.Reflection.PropertyInfo[] properties = typeOfClass.GetProperties();
                        List<XElement> lstXElements = new List<XElement>();
                        List<XElement> lstmainElements = new List<XElement>();
                        XElement rootElement = new XElement(TableName);
    
                        foreach (var item in objData)
                        {
                            lstXElements = new List<XElement>();
                            XElement mainElement = new XElement(p_mainElementName);
                            foreach (System.Reflection.PropertyInfo property in properties)
                            {
                                var notMapped = property.GetCustomAttributes(typeof(NotMappedAttribute), false);
                                if (notMapped.Length == 0)
                                {
                                    lstXElements.Add(new XElement(property.Name, property.GetValue(item, null)));
                                }
                            }
                            mainElement.Add(lstXElements);
                            lstmainElements.Add(mainElement);
                        }
                        rootElement.Add(lstmainElements);
    
                        string XMLFilePath = serializetoxmlNew(rootElement, MachineID, TableName);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
