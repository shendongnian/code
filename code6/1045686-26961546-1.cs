        using (AdventureWorksEntities context =new AdventureWorksEntities())
        {
            // You do not have to set context.ContextOptions.LazyLoadingEnabled to true 
            // if you used the Entity Framework to generate the object layer.
            // The generated object context type sets lazy loading to true
             // in the constructor. 
            context.ContextOptions.LazyLoadingEnabled = true;
            // Display ten contacts and select a contact
            var contacts = context.Contacts.Take(10);
            foreach (var c in contacts)
                Console.WriteLine(c.ContactID);
            Console.WriteLine("Select a customer:");
            Int32 contactID = Convert.ToInt32(Console.ReadLine());
            // Get a specified customer by contact ID. 
            var contact = context.Contacts.Where(c => c.ContactID == contactID).FirstOrDefault();
            // If lazy loading was not enabled no SalesOrderHeaders would be loaded for the contact.
            foreach (SalesOrderHeader order in contact.SalesOrderHeaders)
            {
                Console.WriteLine("SalesOrderID: {0} Order Date: {1} ",
                    order.SalesOrderID, order.OrderDate);
            }
        }
