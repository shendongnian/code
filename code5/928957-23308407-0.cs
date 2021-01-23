    public IEnumerable<int> GreaterThanSeven()
        {
            this._context.ContextOptions.LazyLoadingEnabled = false;
            var Query = from c in this._context.CustomerInfoes
                        where c.ContactNo.ToString().Length > 7
                        orderby c.ContactNo
                        select c.ContactNo;
            return Query.ToList();
        }
