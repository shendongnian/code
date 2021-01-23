      [TestMethod]
      public void TestMethod1()
      {
         var mock = new Mock<IRepository<Person>>();
         var fakePeople = new[]
              {
                 new Person {FirstName = "Justin", LastName = "Smith"},
                 new Person {FirstName = "Justin", LastName = "Quincy"},
                 new Person {FirstName = "Joe", LastName = "Bloggs"}
              };
         mock.Setup(r => r.Find(It.IsAny<Expression<Func<Person, bool>>>()))
             .Returns<Expression<Func<Person, bool>>>(
                 pred => fakePeople.Where(pred.Compile()));
         var personService = new PersonService(mock.Object);
         var searchForJustins = personService.FindByName("Justin");
         Assert.AreEqual(2, searchForJustins.Count());
         Assert.IsTrue(searchForJustins.Any(_ => _.LastName == "Quincy") 
               && searchForJustins.Any(_ => _.LastName == "Smith"));
         var searchForEtheredges = personService.FindByName("Etheredge");
         Assert.IsFalse(searchForEtheredges.Any());
      }
