    public static bool GetAllowContentTypes(string listName)
      {
                listservice.Lists ls = new listservice.Lists();
                ls.Url = "http://basesmc2008/_vti_bin/lists.asmx";
                ls.UseDefaultCredentials = true;
                UInt64 flags = 0;
                bool contentTypesAllowed = false;
    
                XmlNode node = ls.GetList(listName);
                XElement element = XElement.Parse(node.OuterXml);
    
                var result = from e in element.Attributes("Flags")
                                                      select  e.Value;
    
                if (result != null && UInt64.TryParse(result.First().ToString(), out flags))
                    contentTypesAllowed = ((flags & ((ulong)0x400000L)) != 0L);
                else
                    return false;
                       
                return contentTypesAllowed;
    
    }
