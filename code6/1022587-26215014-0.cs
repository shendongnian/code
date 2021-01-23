    public IList<Customer> GetPossibleDuplicates()
    {
        var comparer = SomeMethodReturningAnEqualityComparerBasedOnSelectionCriteria();
        return this.Context.Customers
                .GroupBy(customer => customer, comparer)
                .SelectMany(g => g)
                .OrderBy(o => o.SearchName)
                .ThenBy(c => c.Created)
                .ToList();
    }
