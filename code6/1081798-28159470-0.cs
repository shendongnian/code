    [TestMethod]
    public void EolSyntaxError()
    {
        Expectations.Expect<(SyntaxError>(
            () =>
            {
                parser.reader = new StringReader("; alfa\n; beta\n\n\n\na");
                parser.eol();
            },
            e =>
            {
                Assert.AreEqual(1, e.line);
            });
    }
