    public IEnumerable<int> GreaterThanSeven()
        {
            this._context.ContextOptions.LazyLoadingEnabled = false;
            var Query = from c in this._context.CustomerInfoes
                        where SqlFunctions.StringConvert((double)c.ContactNo).Length > 7
                        orderby c.ContactNo
                        select c.ContactNo;
            return Query.ToList();
        }
