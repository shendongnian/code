    [TestMethod]
    public void eolSyntaxError()
    {
        parser.reader = new StringReader("; alfa\n; beta\n\n\n\na");
        Action parseEol = () => parser.eol();
        parseEol
            .ShouldThrow<SyntaxError>()
            .And.line.Should().Be(1);
    }
