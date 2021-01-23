    element = document.Elements("Permissiongroup").Elements(("Permission")).FirstOrDefault(t => t.Attribute("id").Value == id);
    
                    if (element != null)
                    {
                        return element.Attribute("display").Value;
                    }
                    else
                    {
                        return string.Empty;
                    }
