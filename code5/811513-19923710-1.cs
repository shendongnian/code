    [TestFixture] // NUnit attribute for a test class
    public class MyTests
    {
        [Test] // NUnit attribute for a test method
        public void fetchFilesTest() // name of a method you are testing + Test is a convention
        {
            var files = fetchFiles();
            Assert.NotNull(files); // should pass if there are any files in a directory
            Assert. ... // assert any other thing you are sure about, like if there is a particular file, or specific number of files, and so forth
        }
    }
