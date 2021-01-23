    [TestFixture]
    public class FileFinderTests
    {
        [Test]
        public void Given_csv_files_in_directory_when_fetchFiles_called_then_return_file_paths_success()
        {
            // arrange
            var inputPath = "inputPath"; 
            var testFilePaths = new[] { "path1", "path2" };
            var mock = new Mock<IOWrapper>();
            mock.Setup(x => x.GetFiles(inputPath, It.IsAny<string>(), It.IsAny<SearchOption>()))
                .Returns(testFilePaths).Verifiable();
            var testClass = new CSVFileFinder(mock.Object, inputPath);
            // act
            var result = testClass.FetchFiles();
            // assert
            Assert.That(result, Is.EqualTo(testFilePaths));
            mock.VerifyAll();
        }
    }
