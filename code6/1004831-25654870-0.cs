    var vendors = (from pp in this.ProductPricings
                   join pic in this.ProductItemCompanies
                   on pp.CompanyId equals pic.CompanyId into left
                   from pic in left.DefaultIfEmpty()
                   orderby pp.EffectiveDate descending
                   group pp by new { pp.Company, SortOrder = (pic != null) ? pic.SortOrder : short.MinValue } into v
                   select v).OrderBy(z => z.Key.SortOrder);
