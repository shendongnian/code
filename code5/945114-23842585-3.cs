    [Test]
    public void TestSplitList()
    {
        var mock = new Mock<BaseClass>();
        mock.CallBase = true; // This will ensure the actual Update also gets called
        IList<Type> fakeTypes = new List<Type>
                            {
                                new Type {currency = "GBR"},
                                new Type {currency = "GBR", OrderNo = 100},
                                new Type {currency = "JPY", OrderNo = 55}
                            };
        mock.Object.SplitList(ref fakeTypes);
        mock.Verify(m => m.Update(It.IsAny<IList<Type>>()), Times.Exactly(1));
        mock.Verify(m => m.Update(It.Is<IList<Type>>(x => x.Any(y => y.currency == "GBR") 
                    && x.Count == 2)), Times.Exactly(1));
        mock.Verify(m => m.Update(It.Is<IList<Type>>(
            x => x.Any(y => y.currency == "JPY"))), Times.Never);
        Assert.AreEqual(3, fakeTypes.Count, "List itself must not have changed");
        // These tests show the effect of the actual `Update` method
        Assert.IsTrue(fakeTypes.Any(t => t.OrderNo == 0 && t.currency == "GBR"), 
           "GBR must be ordered");
        Assert.IsTrue(fakeTypes.Any(t => t.OrderNo == 1 && t.currency == "GBR"), 
           "GBR must be ordered");
        Assert.IsFalse(fakeTypes.Any(t => t.OrderNo == 100 && t.currency == "GBR"), 
           "GBR must be ordered");
        Assert.IsTrue(fakeTypes.Any(t => t.OrderNo == 55 && t.currency == "JPY"), 
           "JPY must not be ordered");
    }
