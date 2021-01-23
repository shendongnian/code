	using System;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Chrome;
	namespace SeleniumScrollTest {
		internal static class Program {
			// Declare Selenium Web Driver
			private static IWebDriver _chromeDriver;
			
			private static String _url;
			private static void Main(string[] args) {
				// Instantiate URL
				_url = @"http://my.website.com/LazyLoadContent";
				// Instantiate Web Driver as ChromeDriver and set initial URL
				_chromeDriver = new ChromeDriver {Url = _url};
				// Instruct the WebDriver to wait X seconds for elements to load
				_chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
				// Instantiate JavaScript Executor using the web driver
				var jse = (IJavaScriptExecutor) _chromeDriver;
				// The minified JavaScript to execute
				const string script =
					"var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";
				// Start Scrolling
				jse.ExecuteScript(script);
				// Wait for user input
				Console.ReadKey();
				// Close the browser instance
				_chromeDriver.Close();
				// Close the ChromeDriver Server
				_chromeDriver.Quit();
			}
		}
	}
