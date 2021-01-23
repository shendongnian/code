    [TestClass]
    public class ApplicationPresenterTests 
    {
        [TestClass]
        public class OnViewShown : ApplicationPresenterTests 
        {
            [TestMethod]
            public void ForceAuthentication() 
            {
                // given
                var authenticationPresenterFactory = new Mock<IAuthenticationPresenterFactory>();
                var authenticationPresenter = new Mock<IAuthenticationPresenter>();
                authenticationPresenterFactory.Setup(f => f.create()).Returns(authenticationPresenter.Object);
                var presenter = new ApplicationPresenter(authenticationPresenterFactory);
    
                // when
                presenter.OnViewShown();
    
                // then
                authenticationPresenter.Verify(p => p.ShowView());
            }
    }
