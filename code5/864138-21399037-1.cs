    public static class SelectListExt
    {
        public static SelectList ToSelectList(Type enumType)
        {
            return ToSelectList(enumType, String.Empty);
        }
        public static SelectList ToSelectList(Type enumType, string selectedItem)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in Enum.GetValues(enumType))
            {
                FieldInfo fi = enumType.GetField(item.ToString());
                var attribute = fi.GetCustomAttributes(typeof(EnumDescription), true).FirstOrDefault();
                var title = attribute == null ? item.ToString() : ((EnumDescription)attribute).Text;
                
                // uncomment to skip enums without attributes
                //if (attribute == null)
                //    continue;
                var listItem = new SelectListItem
                {
                    Value = ((int)item).ToString(),
                    Text = title,
                    Selected = selectedItem == ((int)item).ToString()
                };
                items.Add(listItem);
            }
            return new SelectList(items, "Value", "Text", selectedItem);
        }
    }
