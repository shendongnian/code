    public static SelectList ToSelectList(Type enumType, string selectedValue)
        {
            var items = new List<SelectListItem>();
            var selectedValueId = 0;
            foreach (var item in Enum.GetValues(enumType))
            {
                FieldInfo fi = enumType.GetField(item.ToString());
                var attribute = fi.GetCustomAttributes(typeof(Description), true).FirstOrDefault();
                var title = attribute == null ? item.ToString() : GenericEnum<Enum>.GetDescription((Enum)item);
                if (selectedValue == ((int)item).ToString())
                {
                    selectedValueId = (int)item;
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
