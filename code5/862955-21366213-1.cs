    [Test]
    public void LINQTest()
    {
         List<Person> males = new List<Person>();
         males.Add(new Person() { FirstName = "Fred", LastName = "Blogs" });
         males.Add(new Person() { FirstName = "John", LastName = "James" });
         males.Add(new Person() { FirstName = "Harry", LastName = "Adams" });
         males.Add(new Person() { FirstName = "Peter", LastName = "Blogs" });
         List<Person> females = new List<Person>();
         females.Add(new Person() { FirstName = "Mary", LastName = "Blogs" });
         females.Add(new Person() { FirstName = "Anne", LastName = "James" });
         females.Add(new Person() { FirstName = "Jane", LastName = "Doe" });
         List<Person> results = new List<Person>();
         var result = males.Concat(females).Where(p => males.Any(x => p.LastName == x.LastName) &&
                                                       females.Any(x => p.LastName == x.LastName))
                                           .ToList();
            Assert.AreEqual(result.Count, 5); // true
    }
