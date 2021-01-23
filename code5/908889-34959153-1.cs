    [TestClass]
    public class NameValueTest
    {
        [TestMethod]
        public void Edit()
        {
            NameValueController controller = new NameValueController();
            
            using(var ts = new TransactionScope()) {
                Assert.IsNotNull(controller.Edit(new Models.NameValue()
                {
                    NameValueId = 1,
                    name1 = "1",
                    name2 = "2",
                    name3 = "3",
                    name4 = "4"
                }));
                //no complete, automatically abort
                //ts.Complete();
            }
        }
        [TestMethod]
        public void Create()
        {
            NameValueController controller = new NameValueController();
            using (var ts = new TransactionScope())
            {
                Assert.IsNotNull(controller.Create(new Models.NameValue()
                {
                    name1 = "1",
                    name2 = "2",
                    name3 = "3",
                    name4 = "4"
                }));
                //no complete, automatically abort
                //ts.Complete();
            }
        }
    }
