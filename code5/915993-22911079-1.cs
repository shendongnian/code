    [TestClass]
    public class DataProviderFixture {
        #region Create
        private Gateway Create(bool firstCallFails = false) {
            return new Gateway(new IDataProvider []{
                new DataProvider1(firstCallFails), 
                new DataProvider2()});
        }
        
        #endregion
        [TestMethod]
        public void ExecuteNoProblems() {
            var gateway = Create();
            var numbers = gateway.Method1();
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, numbers);
            var letters = gateway.Method2("1");
            CollectionAssert.AreEqual(new[] { "A1", "B1", "C1" }, letters);
            letters = gateway.Method2("1", "a");
            CollectionAssert.AreEqual(new[] { "A1a", "B1a", "C1a" }, letters);
            
        }
        [TestMethod]
        public void ExecuteFirstCallFails() {
            var gateway = Create(true);
            var numbers = gateway.Method1();
            CollectionAssert.AreEqual(new[] { 4, 5, 6 }, numbers);
            var letters = gateway.Method2("2");
            CollectionAssert.AreEqual(new[] { "D2", "E2", "F2" }, letters);
            letters = gateway.Method2("1", "b");
            CollectionAssert.AreEqual(new[] { "D1b", "E1b", "F1b" }, letters);
        }
    }
