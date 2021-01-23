    internal static class MyMoqUtilities
    {
        public static MockedDbContext<MyDbContext> MockDbContext(
            IList<Contract> contracts = null,
            IList<User> users = null)
        {
            var mockContext = new Mock<MyDbContext>();
    
            // Create the DbSet objects.
            var dbSets = new object[]
            {
                MoqUtilities.MockDbSet(contracts, (objects, contract) => contract.ContractId == (int)objects[0] && contract.AmendmentId == (int)objects[1]),
                MoqUtilities.MockDbSet(users, (objects, user) => user.Id == (int)objects[0])
            };
    
            return new MockedDbContext<SourcingDbContext>(mockContext, dbSets); 
        }
    }
