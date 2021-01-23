         public static class CodedUITestControlsLibrary
        {
           public bool IsVisible(this HtmlControl HtmlControlToCheckForVisiblity)
           {
            var xCordinate =  HtmlControlToCheckForVisiblity.BoundingRectangle.X;
            var yCordinate = HtmlControlToCheckForVisiblity.BoundingRectangle.Y;
            return(xCordinate>-1 && yCordinate>-1);
           }
        }
        [TestMethod]
        public void MyTestMethod()
        {
            var HtmlDivControl = {find HtmlDiv Control};
            Assert.IsTrue(HtmlDivControl.IsVisible(),
            "Expected HtmlDiv Control is not visible.");
        }
                
