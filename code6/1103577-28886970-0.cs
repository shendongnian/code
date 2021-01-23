    public object GetDetailClasses(IList DefaultValue, IList ChangedValue)
    {
        foreach (var DefaultValueItem in DefaultValue)
        {
            foreach (var ChangedValueItem in DefaultValue)
            {
                if (ChangedValueItem.AsDynamic().NameofProp == DefaultValueItem.AsDynamic().NameofProp)
                { 
                //do stuff...
                }
            }
        }
    }
