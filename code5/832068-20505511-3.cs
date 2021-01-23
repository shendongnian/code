        [Test]
        public void CascadeMapTest()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var person = new Person { Name = "Test" };
                    person.AddPersonAddress(new PersonAddress { Address = new Address { AddressLine1 = "123 main street" }, Description = "WORK" });
                    session.Save(person);
                    tx.Commit();
                }
            }
        }
