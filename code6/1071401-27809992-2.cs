    Person john=new Person(){Name = "John"};
    var contactList = new List<Contact>() {new Contact(){Name = "Phone",Value = "555-444-333",Person = john},
                                           new Contact() { Name = "email", Value = "john@gmail.com",Person = john}};
    using (YourContext db = new YourContext())
    {
       db.Contacts.AddRange(contactList);
       db.SaveChanges();
    }
