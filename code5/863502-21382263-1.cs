    var entity = entities.Students.Where(p => p.Id == "2").First();
    entity.StudentContact = new StudentContact() { Contact = "xyz", Id = "2" };
    entities.Students.Attach(entity);
    var entry = entities.Entry(entity);
    // other changed properties
    entities.SaveChanges();
