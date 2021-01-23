    string date1 = TableQuery.GenerateFilterConditionForDate(
                       "Date", QueryComparisons.GreaterThanOrEqual,
                       DateTimeOffsetVal);
    string date2 = TableQuery.GenerateFilterConditionForDate(
                       "Date", QueryComparisons.LessThanOrEqual,
                       DateTimeOffsetVal);
    string finalFilter = TableQuery.CombineFilters(
                            TableQuery.CombineFilters(
                                partitionFilter,
                                TableOperators.And,
                                date1),
                            TableOperators.And, date2);
