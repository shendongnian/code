    using (var context = new MyDbContext())
    {
       context.Attach(person);
       person.Name = "Bob";
       context.SaveChanges();
    }
