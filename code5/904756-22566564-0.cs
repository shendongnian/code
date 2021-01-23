    [TestClass]
    public class CustomerTests : SuperTestBaseClass {
        public CustomerTests() : base() { }
    
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException)]
        public void NameThrowsWhenNull() { 
            customer.Name = null;
        }
    }
    
