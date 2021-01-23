    [TestClass]
    public abstract class ApplicationPresenterTests {
        [TestClass]
        public class OnViewShown : ApplicationPresenterTests {
            [TestMethod]
            public void ForceAuthentication() {
                // arrange
                // act
                Presenter.OnViewShown();
                var actual = Presenter.CurrentUser;
                // assert
                Assert.IsNotNull(actual);
                Assert.IsInstanceOfType(actual, typeof(IDatabaseUser));
            }
        }
        [TestInitialize]
        public void ApplicationMainPresenterSetUp() {
            Mock<IAuthenticationView> authView = new Mock<IAuthenticationView>(MockBehavior.Strict);
            authView.SetupProperty(v => v.ErrorMessage);
            authView.SetupGet(v => v.Instance).Returns(RandomValues.RandomString());
            authView.SetupGet(v => v.Login).Returns(RandomValues.RandomString());
            authView.SetupGet(v => v.Password).Returns(RandomValues.RandomString());
            authView.Setup(v => v.CloseView());
            authView.Setup(v => v.SetTitle(It.IsAny<string>()));
            authView.Setup(v => v.ShowView()).Raises(v => v.OnConnect += null).Verifiable();
            Mock<IMembershipService> authService = new Mock<IMembershipService>(MockBehavior.Loose);
            authService.Setup(s => s.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            IAuthenticationPresenter authPresenter = new AuthenticationPresenter(authView.Object, authService.Object);
            ApplicationView = new ApplicationForm();
            Presenter = new ApplicationPresenter(ApplicationView, authPresenter);
        }
        protected IApplicationView ApplicationView { get; private set; }
        protected IApplicationPresenter Presenter { get; private set; }
    }
