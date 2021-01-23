    public static SelectList ToSelectList(Type enumType, string selectedValue)
        {
            var items = new List<SelectListItem>();
            var selectedValueId = 0;
            foreach (var item in Enum.GetValues(enumType))
            {
                FieldInfo fi = enumType.GetField(item.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var title = "";
                if (attributes != null && attributes.Length > 0)
                {
                    title = attributes[0].Description;
                }
                else
                {
                    title = item.ToString();
                }
                var listItem = new SelectListItem
                {
                    Value = ((int)item).ToString(),
                    Text = title,
                    Selected = selectedValue == ((int)item).ToString(),
                };
                items.Add(listItem);
            }
            return new SelectList(items, "Value", "Text", selectedValueId);
        }
