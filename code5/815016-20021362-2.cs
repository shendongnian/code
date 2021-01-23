    [TestFixture]
    public class HelperTests
    {
        [Test]
        public void GivenACmsObjectWithCompletedActionAndController_WhenRenderCMSObject_ThenExpectedActionOutcomeforActionAndControllerIsGiven()
        {
            const string actionName = "foo";
            const string controllerName = "bar";
            const string expectedOutcome = "<h1>Bruce</h1>";
            // Arrange
            var cmsObject = new CMSObject { ActionName = actionName, ControllerName = controllerName };
            var mockInvoker = new Mock<IHtmlHelperActionInvoker>();
            mockInvoker.Setup(x => x.Action(null, actionName, controllerName, cmsObject)).Returns(MvcHtmlString.Create(expectedOutcome));
            SomeHtmlHelperClass.ActionInvoker = mockInvoker.Object;
            // Act
            var result = SomeHtmlHelperClass.RenderCMSObject(null, cmsObject);
            // Verify
            Assert.That(result.ToString(), Is.EqualTo(expectedOutcome));
        }
    }
