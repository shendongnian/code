    [TestMethod]
    [TestCleanup]
    public void TestMethod3()
    {
        using (var context = new CorporateDWTestEntities1())
        {
            //Deleting every row within the OLE_DB_Destination1 table.
            var query = from c in context.SRS_Ticket_Transaction_Stage select c;
            var records = query.ToList();
            
            foreach(var record in records) 
            {
                context.SRS_Ticket_Transaction_Stage.DeleteOnSubmit(record);
            }
            context.SubmitChanges();
        }
    }
