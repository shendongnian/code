    [Test]
    public void TempTest()
    {
        AsyncContext.Run(async () =>
        {
            string data = await new AsyncTest().DoTest();
            Assert.IsNotNull( data );
            Assert.IsNull( data );
        });
    }
