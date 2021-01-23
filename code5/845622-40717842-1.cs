    public static class KendoHelpers
    {
        public enum DateTimePrecision
        {
            Seconds = 1,
            Minutes = 2,
            Hours = 4
        }
        public static DataSourceRequest NormalizeDateFilters(this DataSourceRequest request, DateTimePrecision precision)
        {
            // TODO: Add parameter validation.
            for (int i = 0; i < request.Filters.Count; ++i)
            {
                FilterDescriptor filter = request.Filters[i] as FilterDescriptor;
                if (filter != null && filter.ConvertedValue is DateTime && filter.Operator == FilterOperator.IsEqualTo)
                {
                    DateTime val = (DateTime)filter.ConvertedValue;
                    CompositeFilterDescriptor newFilter = new CompositeFilterDescriptor
                    {
                        LogicalOperator = FilterCompositionLogicalOperator.And
                    };
                    DateTime lowerBound;
                    DateTime upperBound;
                    if (precision == DateTimePrecision.Seconds)
                    {
                        lowerBound = val.TruncateToWholeSeconds();
                        upperBound = lowerBound.AddSeconds(1);
                    }
                    else if (precision == DateTimePrecision.Minutes)
                    {
                        lowerBound = val.TruncateToWholeMinutes();
                        upperBound = lowerBound.AddMinutes(1);
                    }
                    else if (precision == DateTimePrecision.Hours)
                    {
                        lowerBound = val.TruncateToWholeHours();
                        upperBound = lowerBound.AddHours(1);
                    }
                    else
                    {
                        // If someone would be stupid enough to supply Hours | Minutes
                        throw new ArgumentException("Not supported precision. Only Second, Minute, Hour values are supported.", "precision");
                    }
                    newFilter.FilterDescriptors.Add(new FilterDescriptor
                    {
                        Member = filter.Member,
                        MemberType = filter.MemberType,
                        Operator = FilterOperator.IsGreaterThanOrEqualTo,
                        Value = lowerBound
                    });
                    newFilter.FilterDescriptors.Add(new FilterDescriptor
                    {
                        Member = filter.Member,
                        MemberType = filter.MemberType,
                        Operator = FilterOperator.IsLessThan,
                        Value = upperBound
                    });
                    request.Filters[i] = newFilter;
                }
            }
            return request;
        }
    }
