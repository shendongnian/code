    public class Repository
    {
        public IList<Customer> FindByCriteria(Func<Customer, IComparable> criteria)
        {
            var query = from customer in FindAll()
                        group customer by criteria(customer)
                        into groupings
                        where groupings.Count() > 1
                        from grouping in groupings
                        orderby grouping.SearchName, grouping.Created
                        select grouping;
            return query.ToList();
        }
        public IEnumerable<Customer> FindAll()
        {
            yield return new Customer
            {
                CustomerId = 1,
                SearchName = "John",
                CardNumber = "0000 0000 0000 0000 1",
                Mail = "john.doe@test.com",
            };
            yield return new Customer
            {
                CustomerId = 2,
                SearchName = "Jim",
                CardNumber = "0000 0000 0000 0000 2",
                Mail = "jim.doe@test.com",
            };
            yield return new Customer
            {
                CustomerId = 3,
                SearchName = "Jack",
                CardNumber = "0000 0000 0000 0000 3",
                Mail = "jack.doe@test.com",
            };
            yield return new Customer
            {
                CustomerId = 4,
                SearchName = "Jane",
                CardNumber = "0000 0000 0000 0000 3",
                Mail = "john.doe@test.com",
            };
            yield return new Customer
            {
                CustomerId = 4,
                SearchName = "Joan",
                CardNumber = "0000 0000 0000 0000 3",
                Mail = "john.doe@test.com",
            };
        }
    }
