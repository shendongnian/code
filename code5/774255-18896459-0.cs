      public List<SelectListItem> GetList<TEnum>() where TEnum : struct
            {
                var items = new List<SelectListItem>();
                foreach (int value in Enum.GetValues(typeof(TEnum)))
                {
                    items.Add(new SelectListItem
                    {
                        Text = Enum.GetName(typeof(TEnum), value),
                        Value = value
                    });
                } 
                return items;
    
    
            }
