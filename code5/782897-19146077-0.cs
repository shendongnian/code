    public static List<SelectListItem> GetDropDown()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            lm = (call database);
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.name, Value = temp.id });
            }
            return ls;
        }
