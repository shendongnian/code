    var result = GenericGroupBy<DTO>(dataList, g => g.Id);
    
    public object GenericGroupBy<T>(object data, Func<T, int> groupByExpression)
    {
        return ((List<T>)data).GroupBy(groupByExpression);
    }
