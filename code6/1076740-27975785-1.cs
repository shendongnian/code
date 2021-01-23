    [Test]
    public void TestAnalyze() {
        var mockLoader = new Mock<IFileLoader>();
        mockLoader.Setup(ml => ml.loadFileContents("foo.txt")).Returns("Whatever you would have had in the file");
        var analyzer = new FileAnalyzer(mockLoader.Object);
        Assert.That(analyzer.Analyze("foo.txt"), Is.EqualTo("Expected analysis result"));
    }
