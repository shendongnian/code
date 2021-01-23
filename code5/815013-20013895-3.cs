        [TestMethod]
        public void HtmlHelperActionRenderCMSObject_Execute_EnsureInvokeActionCalledWithExpectedControlerAndActionName()
        {            
            //Arrange
            var fakecmsObject = new CMSObject() { ActionName = "foo", ControllerName = "bar" };
            var testableHtmlHelperAction = new TesatableHtmlHelperAction();
            SomeHelperClass.HtmlHelperActionFunc = () => testableHtmlHelperAction;
            // Act
            SomeHelperClass.RenderCMSObject(null, fakecmsObject);
            // Verify
            Assert.AreEqual<string>(fakecmsObject.ActionName, testableHtmlHelperAction.Action);
            Assert.AreEqual<string>(fakecmsObject.ControllerName, testableHtmlHelperAction.Controller);
        }
