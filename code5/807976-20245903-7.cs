    [TestMethod()]
    public void unSortedLeadsTest()
    {
        // read objects from xml
        string xml = "C:/Users/Admin/Downloads/potentialcustomers.xml";
        CustomerLeads target = new CustomerLeads();
        List<CustomerLead> actual = target.unSortedLeads(xml);
        
        // prepare expected collection
        List<CustomerLead> expected = new List<CustomerLead>()
        {
            new CustomerLead()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                EmailAddress = "Email@Address1"
            },
            new CustomerLead()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                EmailAddress = "Email@Address2"
            },
            new CustomerLead()
            {
                FirstName = "FirstName3",
                LastName = "LastName3",
                EmailAddress = "Email@Address3"
            }
        };
        // test equality
        CollectionAssert.AreEqual(expected, actual);
    }
