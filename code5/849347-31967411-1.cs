    using CodedUIExtensions;
    [CodedUITest]
    class MyTest
    {
        [TestMethod]
        public void SomeVisibilityTest()
        {
            HtmlControl control = // ...
            HtmlDiv div = // ...
            Assert.IsTrue(control.IsElementVisible(), "Not visible");
            Asset.IsFalse(div.IsElementVisible(), "Visible");
        }
    }
