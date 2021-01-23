    public List<string> GetDisplayNamesGrouped(Type ClassName, string GroupName)
        {
            List<string> DisplayNameList = new List<string>();
            var properties = ClassName.GetProperties();
            foreach (var property in properties)
            {
                var displayAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
                string displayName = property.Name;
                if (displayAttribute != null)
                {
                    if (displayAttribute.GroupName == GroupName)
                    {
                        displayName = displayAttribute.Name;
                        DisplayNameList.Add(displayName);
                    }
                }
            }
            return DisplayNameList;
        }
