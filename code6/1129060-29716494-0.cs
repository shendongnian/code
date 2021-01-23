    public class Person
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, Lastname);
            }
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FullNameProperlyResolved()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<Person>();
            var expectedFullName = string.Format("{0} {1}", sut.FirstName, sut.Lastname); 
            Assert.AreEqual(expectedFullName, sut.FullName);
        }
    }
