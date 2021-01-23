    [Guid("c375fa80-150f-11d6-a618-0010a401eb10")]
		[ContractID(TestCookieServiceFactory.ContractID)]
		public class TestCookieServiceFactory
			: GenericOneClassNsFactory<TestCookieServiceFactory, TestCookieService>
		{
			public const string ContractID = "@mozilla.org/cookieService;1";
		}
     public class TestCookieService : nsICookieService
     {
       // Implement nsICookieService...       
     }
     public void Main()
     {
         Xpcom.Initialize("My Xulrunner/Fireofox location");
         var existingFactoryDetails = TestCookieServiceFactory.Unregister();
         TestCookieServiceFactory.Register();
         var browser = new GeckofxWebBrowser();
         // Add browser to form etc...
         browser.Navigate("http://SomeWebPageThatUsesCookies")
         // Cookie requests should now be sent to TestCookieService, process them as your want.
     }
