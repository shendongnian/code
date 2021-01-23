    public static SelectList GetDropDownList<T>(List<T> objects, string value, string text)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            //var defaultItem = new SelectListItem();
            //defaultItem.Value = Convert.ToString(-1);
            //defaultItem.Text = "--Select--";
            //defaultItem.Selected = true;
            //items.Add(defaultItem);
            List<SelectListItem> lst = objects
                    .Select(x =>
                            new SelectListItem
                            {
                                Value = x.GetType().GetProperty(value).GetValue(x).ToString(),
                                Text = x.GetType().GetProperty(text).GetValue(x).ToString()
                            }).ToList();
            items.AddRange(lst);
            return new SelectList(items, "Value", "Text");
        }
