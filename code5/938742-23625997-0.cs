    IEnumerable dbSet = dbContext.Set(myType);
    items.AddRange(from object obj in dbSet
                   select new SelectListItem
                        {
                            Text = nameProp.GetValue(obj).ToString(),
                            Value = valueProp.GetValue(obj).ToString(),
                        });
