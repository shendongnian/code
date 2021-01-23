    [Test]
    public void TestStreamToObservable()
    {
        var expectedText = new List<string>
        {
            "A good test is simple.",
            "A rolling stone gathers no moss.",
            "Test properly"
        };
        var stream = new MemoryStream();
        var writer = new BinaryWriter(stream);
        expectedText.ForEach(writer.Write);
        writer.Flush();
        stream.Seek(0, SeekOrigin.Begin);
        var reader = new BinaryReader(stream);
        var resultText = new List<string>();
        Assert.Throws<EndOfStreamException>(
            () => reader.ToObservable().Subscribe(resultText.Add));
        CollectionAssert.AreEquivalent(expectedText, resultText);
    }
