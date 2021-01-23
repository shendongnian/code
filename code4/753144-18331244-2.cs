    public class PersonManager // CRUD
        {
            public void Create(Person person)
            {
                using (TestDbContext context = new TestDbContext())
                {
                    context.Person.Add(person);
                    context.SaveChanges();
                }
            }
    
            public void Update(Person person)
            {
                using (TestDbContext context = new TestDbContext())
                {
                    context.Person.Attach(person);
                    context.Entry(person).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
