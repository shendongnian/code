    using System;
    using System.Text;
    using System.Transactions;
    namespace RefSandBoc
    {
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer = new Customer()
                    {
                        Name = "Foo",
                        Surname = "Bar"
                    };
                using (SampleAuditEntities dbContext = new SampleAuditEntities())
                {
                    using (var scope = new TransactionScope(TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                    {
                        InsertAuditTool insertAuditTool = new InsertAuditTool(dbContext);
                        insertAuditTool.TestInsert(customer);
                        
                        //throw new Exception("Test Exception");
                        scope.Complete();
                    }
                }
                Console.WriteLine("Customer ID = " + customer.ID);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
    class InsertAuditTool
    {
        SampleAuditEntities dbContext;
        public InsertAuditTool(SampleAuditEntities DbContext)
        {
            this.dbContext = DbContext;
        }
        public void TestInsert(Customer InsertedCustomer)
        {
            dbContext.Customers.Add(InsertedCustomer);
            dbContext.SaveChanges();
            //throw new Exception("Test Exception");
            Audit audit = new Audit()
            {
                DateTimeInserted = DateTime.Now,
                InsertedID = InsertedCustomer.ID
            };
            dbContext.Audits.Add(audit);
            dbContext.SaveChanges();
            //throw new Exception("Test Exception");
        }
    }
    }
