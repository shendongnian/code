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
