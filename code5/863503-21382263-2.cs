    var entity = entities.Students.FirstOrDefault();
    entity.StudentContact.Contact = "ABC";
    entities.Students.Attach(entity);
    var entry = entities.Entry(entity);
    entry.Property(e => e.StudentContact.Contact).IsModified = true;
    // other changed properties
    entities.SaveChanges();
