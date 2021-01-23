    //generic Edit dropdown
        public IEnumerable<SelectListItem> GetEditList<O>(string text, string value, string selected) 
                                                            where O : class
        {
            IEnumerable<O> result = context.Set<O>();
            var query = from e in result
                        select new
                        {
                            Value = e.GetType().GetProperty(value).GetValue(e, null),
                            Text = e.GetType().GetProperty(text).GetValue(e, null)
                        };
    
            return query.AsEnumerable()
                .Select(s => new SelectListItem
                {
                    Value = s.Value.ToString(),
                    Text = s.Text.ToString(),
                    Selected = (selected == s.Value.ToString() ? true : false)
                });
        }
