    public Expression<Func<T, bool>> GetSearchPredicate<T>(string parameters,
                                                           Func<T, string, bool> test1,
                                                           Func<T, string, bool> test2)
    {
        var predicateInner = PredicateBuilder.False<T>();
        var paramertsForSearch = new List<string>(parametrs.Split(' '));
        paramertsForSearch.RemoveAll(string.IsNullOrEmpty);
        foreach (var item in paramertsForSearch)
        {
            var itemSearch = item;
            predicateInner = predicateInner.Or(x => test1(x, itemSearch));
            predicateInner = predicateInner.Or(x => test2(x, itemSearch));
        }
        return predicateInner;
    }
    var predicateSearchCustomer = 
        GetSearchPredicate<Customer>(search,
                                     (cust, term) => cust.CustomerName.Contains(term),
                                     (cust, term) => cust.CustomerFamily.Contains(term));
    var predicateSearchEmployee = 
        GetSearchPredicate<Employee>(search,
                                     (empl, term) => empl.EmployeeName.Contains(term),
                                     (cust, term) => empl.EmployeeFamily.Contains(term));
    
