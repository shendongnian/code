    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Runtime.CompilerServices;
	using System.Reflection;
	using System.Threading;
	using System.IO;
	using Awesomium.Core;
	namespace AweSomiumExample
	{
		class Program
		{
			WebView wv;
			int i = 0;
			int k = 0;
			dynamic PageReady;
			bool DocumentReady;
			public String login { get; private set; }
			public String passw { get; private set; }
			public static void Main(String[] args)
			{
				Program pg = new Program();
			}
			public Program()
			{
				wv = WebCore.CreateWebView(1024, 600);
				wv.Source = new Uri("http://somecompany.app.com/ematrix/emxLogin.jsp");
				login = "ffffAddd";
				passw = "aPassword";
				wv.LoadingFrameComplete += MainPageLoadingFrameComplete;
				wv.DocumentReady += OnDocumentReadyHandler;
				WebCore.Run();
			}
			private void MainPageLoadingFrameComplete(Object sender, FrameEventArgs e)
			{
				try
				{
					if (!e.IsMainFrame)
					{
						wait();
					}
					else
					{
						String userInput = @"//*[@id=""divLogin""]/form/table/tbody/tr[2]/td/table/tbody/tr/td[3]/div/div/input";
						String userNameXpath = userInput + "[1]";
						String passwordXPath = userInput + "[2]";
						String loginButtonXPath = userInput + "[3]";
						wv.LoadingFrameComplete -= MainPageLoadingFrameComplete;
						dynamic xPathUserNameObj = GetXPathElement(userNameXpath);
						using (xPathUserNameObj)
						{
							var username = xPathUserNameObj;
							username.value = login;
						}
						dynamic xPathPasswordObj = GetXPathElement(passwordXPath);
						using (xPathPasswordObj)
						{
							var password = xPathPasswordObj;
							password.value = passw;
						}
						TakeScreenShot();
						dynamic xPathLoginButtonObj = GetXPathElement(loginButtonXPath);
						using (xPathLoginButtonObj)
						{
							var loginButton = xPathLoginButtonObj;
							wv.LoadingFrameComplete += LoginFrameComplete;
							loginButton.click();
						}
					}
				}
				catch (Exception ex)
				{
					Log(ex.Message);
					wait();
				}
			}
			private void LoginFrameComplete(Object sender, FrameEventArgs e)
			{
				try
				{
					PageReady = (PageReady == null) ? GetXPathElement(@"//*[@id=""SearchIcon""]") : PageReady;
					if (PageReady != null)
					{
						Log(String.Format("Running {0}", ++k));
						wv.LoadingFrameComplete -= LoginFrameComplete;
						TakeScreenShot();
						wv.LoadingFrameComplete += SearchFrameComplete;
						wv.Source = new Uri("http://somecompany.app.com/ematrix/common/emxFullSearch.jsp?field=TYPES%3Dtype_Part%3APOLICY%3Dpolicy_ECPart%2Cpolicy_DevelopmentPart&showInitialResults=false&table=ENCPartSearchResult&selection=multiple&toolbar=ENCPartSearchToolbar&freezePane=ActiveECRECO%2CName&HelpMarker=emxhelpfullsearch&formInclusionList=PRT_DESCRIPTION&suiteKey=EngineeringCentral&StringResourceFileId=emxEngineeringCentralStringResource&SuiteDirectory=engineeringcentral");
						wait();
						PageReady = null;
					}
					else
					{
						wait();
					}
				}
				catch (Exception ex)
				{
					Log(ex.Message);
					wait();
				}
			}
			private void SearchFrameComplete(Object sender, FrameEventArgs e)
			{
				try
				{
					PageReady = (PageReady == null) ? GetXPathElement(@"//*[@id=""NAME""]") : PageReady;
					if (PageReady != null)
					{
						Log(String.Format("Running {0}", ++k));
						wv.LoadingFrameComplete -= LoginFrameComplete;
						TakeScreenShot();
						Log("Success");
						TakeScreenShot("Final");
						wv.LoadingFrameComplete -= SearchFrameComplete;
						wv.DocumentReady -= OnDocumentReadyHandler;
						WebCore.Shutdown();
					}
					else
					{
						TakeScreenShot("SearchScreen");
						wait();
					}
				}
				catch (Exception ex)
				{
					Log(ex.Message);
					wait();
				}
			}
			private void OnDocumentReadyHandler(Object Sender, DocumentReadyEventArgs e)
			{
				Log(String.Format("Running {0}", ++k));
				if (e != null && e.ReadyState == DocumentReadyState.Loaded)
				{
					TakeScreenShot("DocumentReady_True");
					Log("DocumentReady = true");
					DocumentReady = true;
				}
				else
				{
					TakeScreenShot("DocumentReady_False");
					Log("DocumentReady = false");
					DocumentReady = false;
					//WebCore.Run();
				}
			}
			private dynamic GetXPathElement(String xpath)
			{
				try
				{
					if (wv.IsDocumentReady == false)
					{
						return null;
					}
					String xpathString = String.Format(@"document.evaluate('{0}',document,null,9,null);", xpath);
					dynamic dc = (JSObject)wv.ExecuteJavascriptWithResult(xpathString);
					if (dc != null && dc is JSObject)
					{
						using (dc)
						{
							dynamic SingleNodeObj = dc.singleNodeValue;
							if (SingleNodeObj != null && SingleNodeObj is JSObject)
							{
								return SingleNodeObj;
							}
							else
							{
								return null;
							}
						}
					}
					else
					{
						return null;
					}
				}
				catch (Exception ex)
				{
					Log(ex.Message);
					return null;
				}
			}
			private void TakeScreenShot(String Name = "Image")
			{
				//Thread.Sleep(3000);
				BitmapSurface surface = (BitmapSurface)wv.Surface;
				surface.SaveToPNG(String.Format("{0}_{1}.png", ++i, Name), true);
				Log(String.Format("ScreenShot Taken {0}", i));
			}
			private static void Log(string text,
							[CallerFilePath] string file = "",
							[CallerMemberName] string member = "",
							[CallerLineNumber] int line = 0)
			{
				Console.WriteLine("{0}_{1}({2}): {3}", Path.GetFileName(file), member, line, text);
			}
			private void wait(int waitTime = 10000)
			{
				Log(String.Format("Wait {0} seconds for the page to load", (int)(waitTime / 1000)));
				Thread.Sleep(waitTime);
			}
		}
	}
