    [TestMethod]
    public void TestMethod1()
    {
        //our context
        var ctx = new Infrastructure.EF.Context();
        
        //our language types
        var languageType1 = new LanguageType { ID = 1, Name = "French" };
        var languageType2 = new LanguageType { ID = 2, Name = "English" };
        ctx.LanguageTypes.AddRange(new LanguageType[] { languageType1, languageType2 });
        
        //persist our language types into db before we continue.
        ctx.SaveChanges();
        //now we're about to start a new unit of work
        var customer = new Customer
        {
            ID = 1,
            Name = "C1",
            Contacts = new List<Contact>() //To avoid null exception
        };
        //notice that we're assigning the id of the language type and not
        //an object.
        var Contacts = new List<Contact>(new Contact[] { 
             new Contact{ID=1, Customer = customer, LanguageTypeID=1},
             new Contact{ID=2, Customer = customer, LanguageTypeID=2}
            });
        customer.Contacts.AddRange(Contacts);
        
        //adding the customer here will mark the whole object graph as 'Added'
        ctx.Customers.Add(customer);
        //The customer & contacts are persisted, and in the DB, the language
        //types are not redundant.
        ctx.SaveChanges();
    }
