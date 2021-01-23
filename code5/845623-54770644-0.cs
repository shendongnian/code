    public static IList<IFilterDescriptor> NormalizeDateFilters(this IList<IFilterDescriptor> filters)
    {
        for (var i = 0; i < filters.Count; i++)
        {
            if (filters[i] is CompositeFilterDescriptor compositeFilterDescriptor)
            {
                compositeFilterDescriptor.FilterDescriptors.NormalizeDateFilters();
            }
            else if (filters[i] is FilterDescriptor filterDescriptor &&
                     filterDescriptor.ConvertedValue is DateTime &&
                     filterDescriptor.Operator == FilterOperator.IsEqualTo)
            {
                var value = DateTime.Parse(filterDescriptor.Value.ToString());
                var start = value.Date;
                var end = start.AddDays(1);
    
                var newFilter = new CompositeFilterDescriptor
                {
                    LogicalOperator = FilterCompositionLogicalOperator.And
                };
    
                newFilter.FilterDescriptors.Add(new FilterDescriptor
                {
                    Member = filterDescriptor.Member,
                    MemberType = filterDescriptor.MemberType,
                    Operator = FilterOperator.IsGreaterThanOrEqualTo,
                    Value = start
                });
    
                newFilter.FilterDescriptors.Add(new FilterDescriptor
                {
                    Member = filterDescriptor.Member,
                    MemberType = filterDescriptor.MemberType,
                    Operator = FilterOperator.IsLessThan,
                    Value = end
                });
                filters[i] = newFilter;
            }
        }
        return filters;
    }
