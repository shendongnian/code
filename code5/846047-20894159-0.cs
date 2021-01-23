    [Test]
    public void TempTest()
    {
        AsyncContext.Run(() =>
        {
            string data = await new AsyncTest().DoTest();
            Assert.IsNotNull( data );
            Assert.IsNull( data );
        });
    }
