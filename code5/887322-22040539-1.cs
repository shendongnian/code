    List<Customer> customers = new List<Customer> {
        new Customer { Country = "USA" },
        new Customer { Country = "Spain" }
    };
    var countries = Extensions.GetCountries(customers.AsQueryable());
    Assert.AreEqual(countries.Count(), 2);
