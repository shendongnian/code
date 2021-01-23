    public FilterProfile()
    {
      filters = new BindingList<Filter>();  // the list that gets bound to gridview
      filters.AddingNew += (s,e) => {
        //the default value of FilterType is up to you.
        e.NewObject = new Filter {type = FilterType.SESSION };
      };
    }
