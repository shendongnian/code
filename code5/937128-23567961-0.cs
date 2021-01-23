      private static bool UpdateNameAndAge(int id, string name, int age)
      {
         bool success = false;
         var context = new PersonContext();
         context.Configuration.ValidateOnSaveEnabled = false;
         var person = new Person() {Id = id, Name = name, Age = age};
         context.Persons.Attach(person);
         var entry = context.Entry(person);
         // validate the two fields
         var errorsName = entry.Property(e => e.Name).GetValidationErrors();
         var errorsAge = entry.Property(e => e.Age).GetValidationErrors();
         // save if validation was good
         if ((errorsName.Count == 0) && (errorsAge.Count == 0))
         {
            entry.Property(e => e.Name).IsModified = true;
            entry.Property(e => e.Age).IsModified = true;
            context.SaveChanges();
            success = true;
         }
         return success;
      }
