    var result = GenericGroupBy<DTO, int>(dataList, g => g.Id);
    
    public object GenericGroupBy<TElement, TKey>
        (object data, Func<TElement, TKey> groupByExpression)
    {
        return ((IEnumerable<TElement>)data).GroupBy(groupByExpression);
    }
