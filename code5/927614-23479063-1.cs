    [TestMethod]
    public void UpdatePersonName()
    {
        using (var context = new TestDbContext())
        {
            // insert 'initial' person to be renamed
            context.Persons.Add(new Person {Name = "andyp"});
            context.SaveChanges();
            Assert.AreEqual(1, context.Persons.Count());
            Assert.AreEqual("andyp", context.Persons.Select(p => p.Name).Single());
            // update the persons name
            context.Persons
                   .Where(p => p.Id == 1)
                   .Update(p => new Person {Name = "Pascal"});
            // assert that the update has been successful
            Assert.AreEqual(1, context.Persons.Count());
            Assert.AreEqual("Pascal", context.Persons.Select(p => p.Name).Single());
        }
    }
