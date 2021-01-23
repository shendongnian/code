     public string ReturnAttribute(string SearchValue)
            {
                XDocument xdoc = XDocument.Load(@"C:\Tmp\test.xml");
                string ReturnValue = String.Empty;
                foreach (var item in xdoc.Descendants("Value"))
                {
                    if (item.Value == SearchValue)
                    {
                        ReturnValue=item.FirstAttribute.Value;
    
                    }
                }
                return ReturnValue;
            }
