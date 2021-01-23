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
