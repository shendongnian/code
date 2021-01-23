    [Test]
    public void LockedCrateObjectIsDrawnCorrectly()
    {
        var graphicsSpy = new GraphicsSpy();
        var lockedCrateObject = new LockedCrateObject(graphicsSpy);
        lockedCrateObject.Draw();
        Assert.IsTrue(graphicsSpy.DrawCalled);
    }
