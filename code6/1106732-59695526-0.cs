    public string CheckDocProp(string propName, object props)
            {
                Excel.Workbook workBk = Globals.ThisAddIn.Application.ActiveWorkbook;
                
                object customProperties = workBk.CustomDocumentProperties;
                Type docPropsType = customProperties.GetType();
                object nrProps;
                object itemProp = null;
                object oPropName;
                object oPropVal = null;
    
                nrProps = docPropsType.InvokeMember("Count",
                    BindingFlags.GetProperty | BindingFlags.Default,
                    null, props, new object[] { });
                int iProps = (int)nrProps;
    
                for (int counter = 1; counter <= ((int)nrProps); counter++)
                {
                    itemProp = docPropsType.InvokeMember("Item",
                        BindingFlags.GetProperty | BindingFlags.Default,
                        null, props, new object[] { counter });
    
                    oPropName = docPropsType.InvokeMember("Name",
                        BindingFlags.GetProperty | BindingFlags.Default,
                        null, itemProp, new object[] { });
                    
                    if (propName == oPropName.ToString())
                    {
                        oPropVal = docPropsType.InvokeMember("Value",
                            BindingFlags.GetProperty | BindingFlags.Default,
                            null, itemProp, new object[] { });
                        return oPropVal.ToString();
                        break;
                    }
                    else
                    {
                        return "Not Found.";
                    }
                }
                return "Not Found.";
            }
