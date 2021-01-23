    Predicate<Employee> p1 = emp => emp.City == "Seattle";
    Predicate<Employee> p2 = emp => emp.Region == "WA";
    Predicate<Employee> p3 = emp => emp.EmployeeID > 10;
    Predicate<Employee> orp1p1Andp3 = PredicateExtensions.OrAll(new[] { p1, p2}).And(p3);
    //identical with
    Predicate<Employee> orp1p1Andp3 = p1.Or(p2).And(p3);
    //
    var query = from emp in this.ctx.Employees select emp;
    Func<Employee,bool> selector = emp=>orp1p1Andp3(emp);
    dataGrid.ItemsSource = query.Where(selector);
