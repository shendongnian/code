    //This is our container for our original entity and the calculated field
    public class PersonAndTax<T> 
    {
        public T Entity { get; set; }
        public double Tax { get; set; }
    }
----------
    public class PersonAndTaxHelper
    {
        // This is our middle translation class
        // Each Entity will use a different way to calculate income
        private class PersonAndIncome<T>
        {
            public T Entity { get; set; }
            public int Income { get; set; }
        }
        public static IQueryable<PersonAndTax<Employee>> GetEmployeeAndTax(IQueryable<Employee> employees)
        {
            var query = from x in employees
                        select new PersonAndIncome<Employee>
                        {
                            Entity = x,
                            Income = x.YearlySalary
                        };
            return CalcualateTax(query);
        }
        public static IQueryable<PersonAndTax<Contractor>> GetContratorAndTax(IQueryable<Contractor> contractors)
        {
            var query = from x in contractors
                        select new PersonAndIncome<Contractor>
                        {
                            Entity = x,
                            Income = x.Contracts.Sum(y => y.Total) 
                        };
            return CalcualateTax(query);
        }
        // Tax calculation is defined in one place
        private static IQueryable<PersonAndTax<T>> CalcualateTax<T>(IQueryable<PersonAndIncome<T>> personAndIncomeQuery)
        {
            var query = from x in personAndIncomeQuery
                        select new PersonAndTax<T>
                        {
                            Entity = x.Entity,
                            Tax = x.Income * 0.3
                        };
            return query;
        }
    }
