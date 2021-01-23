	using OpenQA.Selenium;
	using OpenQA.Selenium.Firefox;
	using System;
	namespace BrowserLogIn
	{
		class Program
		{
			static void Main(string[] args)
			{
				var facebookDetails = new WebPageAuthenticationDetails
				{
					HomePageAddress = new Uri("https://www.facebook.com/"),
					UsernameLocator = By.Id("email"),
					PasswordLocator = By.Id("pass"),
					SubmitLocator = By.XPath("//input[@value='Log in']"),
				};
				//Don't dispose this or the browser will be closed after logging in.
				var browserDriver = new FirefoxDriver(); //Or use a different browser if you want (Firefox is easiest to use, though)
				var pageAccessor = new WebPageAccessor(browserDriver, facebookDetails);
				pageAccessor.LogIn("example_username", "example_password");
			}
		}
		class WebPageAccessor
		{
			private readonly IWebDriver driver;
			private readonly WebPageAuthenticationDetails pageDetails;
			public WebPageAccessor(IWebDriver driver, WebPageAuthenticationDetails details)
			{
				this.driver = driver;
				this.pageDetails = details;
			}
			public void LogIn(string username, string password)
			{
				driver.Navigate().GoToUrl(pageDetails.HomePageAddress);
				if (pageDetails.LogInLinkLocator != null)
					Click(pageDetails.LogInLinkLocator);
				Type(pageDetails.UsernameLocator, username);
				Type(pageDetails.PasswordLocator, password);
				Click(pageDetails.SubmitLocator);
			}
			private void Click(By locator)
			{
				driver.FindElement(locator).Click();
			}
			private void Type(By fieldLocator, string text)
			{
				driver.FindElement(fieldLocator).SendKeys(text);
			}
		}
		class WebPageAuthenticationDetails
		{
			public Uri HomePageAddress { get; set; }
			/// <summary>
			/// Only needed if a log-in link first needs to be clicked.
			/// </summary>
			public By LogInLinkLocator { get; set; }
			public By UsernameLocator { get; set; }
			public By PasswordLocator { get; set; }
			public By SubmitLocator { get; set; } //Because some sites don't use HTML submit buttons to submit
		}
	}
