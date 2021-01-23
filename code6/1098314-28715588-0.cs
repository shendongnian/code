    public static List<SelectListItem> GetSelectList(Type enumType, String SelectedValue, Boolean IsValString = true)
                {
                Array values = Enum.GetValues(enumType);
                List<SelectListItem> selectListItems = new List<SelectListItem>(values.Length);
    
                foreach (var i in Enum.GetValues(enumType))
                {
                    String name = Enum.GetName(enumType, i);
                    String desc = name;
                    FieldInfo fi = enumType.GetField(name);
                    var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    String result = attributes.Length == 0 ? desc : ((DescriptionAttribute)attributes[0]).Description;
                    var selectItem = new SelectListItem()
                    {
                        Text = result,
                        Value = (IsValString) ? i.ToString() : ((Int32)i).ToString()
                    };
    
                    if ((SelectedValue != null) && (SelectedValue.Equals(selectItem.Value)))
                    {
                        selectItem.Selected = true;
                    }
    
                    selectListItems.Add(selectItem);
                }
                return selectListItems;
            }
