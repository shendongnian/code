    //RealClass.cs
    public class RealClass{
        public RealClass( string path ){
            this._path = path;
            this._InitDirectory();
        }
        protected string _path;
        protected void _InitDirectory(){
            //Something that requires read from path
            File.WriteAllText( this._path + "/realData.data", "some real data that needs to be created by the class" );
       }
    }
    // TestableRealClass.cs - Only used by the unit test
    public class TestableRealClass: RealClass {
        public TestableRealClass(string path) : base(path) { }        
        public string Path {
            get {
                return _path;
            }
        }
        public InitDirectory() {
            _InitDirectory();
        }
    }
    //DirTest.cs
    [TestClass]
    public class DirTest {
        [TestMethod]
        public void TestMethod1() {
            var testPath = @"C:\SomePath";
            if (!Directory.Exists( testPath )) {
                Directory.CreateDirectory( testPath );
            }
            var sut = new TestableRealClass(testPath);
            AssertThatTheFileContainsExpectedStuff(testPath);
        }
        [TestMethod]
        public void TestAProtectedMember() {
            var testPath = @"C:\SomePath";
            if (!Directory.Exists( testPath )) {
                Directory.CreateDirectory( testPath );
            }
            var sut = new TestableRealClass(testPath);
            Assert.AreEqual(testPath, sut.Path);
        }
        private void AssertThatTheFileContainsExpectedStuff(string path) {
            // Do the assertion...
        }
    }
