    [TestFixture]
    public class TransactionCreatorTest
    {
        [Test]
        public void Test_file_gets_created_on_transaction_complete()
        {
            TransactionCreator creator;
            using (var scope = new TransactionScope())
            {
                creator = Substitute.For<TransactionCreator>();
                scope.Complete();
            }
            creator.Received().Execute();
            creator.DidNotReceive().Revert();
        }
        [Test]
        public void Test_file_gets_does_not_get_created_on_rollback()
        {
            TransactionCreator creator = null;
            try
            {
                using (var scope = new TransactionScope())
                {
                    creator = Substitute.For<TransactionCreator>();
                    var failed = Substitute.For<TransactionCreator>();
                    failed.When(x => x.Execute()).Do(x => { throw new Exception(); });
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                Console.Out.WriteLine(ex);
            }
            
            
            creator.Received().Execute();
            creator.Received().Revert();
        }
    }
