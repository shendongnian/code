    [TestFixture]
    class Test {
        [Test]
        public void TestChangeVoucherStatus(){
    
           var vocherIDs = ...;
           var newStatus = ...;
           var context = ...;
        
           var result = ChangeVoucherStatus(voucherIDs, newStatus, context);
        
           Assert.Equal(result.resMsg, "")
        
        }
    ...
    }
