    using CodedUIExtensions;
    [CodedUITest]
    class MyTest
    {
        [TestMethod]
        public void SomeVisibilityTest()
        {
            UITestControl control = // ...
            HtmlDiv div = // ...
            Assert.IsTrue(control.IsElementVisible(), "Not visible");
            Asset.IsFalse(div.IsElementVisible(), "Visible");
        }
    }
