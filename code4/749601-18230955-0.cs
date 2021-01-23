       if (run.Filters.All(filter => { return IsFilterAllowed(filter); } )
       {
           throw new ArgumentException();
       }
    
        private bool IsFilterAllowed(FiltersItemType filter)
        {
            FilterType t = ConvertFilterType(filter.FilterTypeId);
            return
                  t != FilterType.A &&
                  t != FilterType.B &&
                  t != FilterType.C &&
                  t != FilterType.D &&
                  t != FilterType.E;
        }
