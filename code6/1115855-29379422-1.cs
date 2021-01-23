	using System;
	using System.Net;
	using System.IO;
	using System.Linq;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			const string sUsername = "USERNAMEHERE";
			const string sPassword = "PASSWORDHERE";
			const string sUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:35.0) Gecko/20100101 Firefox/35.0";
			const string sMainURL = "http://kissanime.com";
			const string sCheckLoginURL = "http://kissanime.com/Login";
			private CookieCollection oCookieCollection = null;
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				StartScrape();
			}
			private void StartScrape()
			{
				try
				{
					string[] sPostData = new string[6];
					
					sPostData[0] = UrlEncode("username");
					sPostData[1] = UrlEncode(sUsername);
					sPostData[2] = UrlEncode("password");
					sPostData[3] = UrlEncode(sPassword);
					sPostData[4] = UrlEncode("redirect");
					sPostData[5] = UrlEncode("");
					if (GetMethod(sMainURL) == true)
					{
						if (SetMethod(sCheckLoginURL, sPostData, sMainURL) == true)
						{
							// Login successful
							// Do whatever you need to do here
						}
					}
					else
					{
						MessageBox.Show("Error connecting to main site. Are you connected to the internet?");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			private bool GetMethod(string sPage)
			{
				HttpWebRequest req = default(HttpWebRequest);
				HttpWebResponse resp = default(HttpWebResponse);
				StreamReader stw = default(StreamReader);
				bool bReturn = true;
				try
				{
					req = (HttpWebRequest)HttpWebRequest.Create(sPage);
					req.Method = "GET";
					req.AllowAutoRedirect = false;
					req.UserAgent = sUserAgent;
					req.Accept = "text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
					req.Headers.Add("Accept-Language", "en-us,en;q=0.5");
					req.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
					req.Headers.Add("Keep-Alive", "300");
					req.KeepAlive = true;
					if (oCookieCollection != null)
					{
						// Pass cookie info
						req.CookieContainer = SetCookieContainer(sPage);
					}
					try
					{
						resp = (HttpWebResponse)req.GetResponse();  // Get the response from the server 
						if (req.HaveResponse)
						{
							if (resp.Headers["Set-Cookie"] != null)
							{
								// Save the cookie info
								SaveCookies(resp.Headers["Set-Cookie"]);
							}
							resp = (HttpWebResponse)req.GetResponse();   // Get the response from the server 
							stw = new StreamReader(resp.GetResponseStream());
							stw.ReadToEnd(); // Read the response from the server, but dont save it
						}
						else
						{
							MessageBox.Show("No response received from host " + sPage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							bReturn = false;
						}
					}
					catch (WebException ex)
					{
						// 503 Error. Some sort of ddos protection is my guess
						// Find the refresh header which redirects after a short time
						string[] sSplit = ex.Response.Headers["Refresh"].Split(';');
						System.Threading.Thread.Sleep(Convert.ToInt32(sSplit[0]) * 1000); // Wait the time requested by the refresh header
						GetMethod(sMainURL + sSplit[1].Replace("URL=", ""));  // Redirect to proper page
					}
				}
				catch (WebException exc)
				{
					MessageBox.Show("Network Error: " + exc.Message.ToString() + " Status Code: " + exc.Status.ToString() + " from " + sPage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					bReturn = false;
				}
				return bReturn;
			}
			private bool SetMethod(string sPage, string[] sPostData, string sReferer)
			{
				bool bReturn = false;
				HttpWebRequest req = default(HttpWebRequest);
				HttpWebResponse resp = default(HttpWebResponse);
				StreamWriter str = default(StreamWriter);
				string sPostDataValue = "";
				Int32 nInitialCookieCount = 0;
				try
				{
					req = (HttpWebRequest)HttpWebRequest.Create(sPage);
					req.Method = "POST";
					req.UserAgent = sUserAgent;
					req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
					req.Headers.Add("Accept-Language", "en-us,en;q=0.5");
					req.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
					req.Referer = sReferer;
					req.ContentType = "application/x-www-form-urlencoded";
					req.Headers.Add("Keep-Alive", "300");
					if (oCookieCollection != null)
					{
						// Pass cookie info from the login page
						req.CookieContainer = SetCookieContainer(sPage);
					}
					str = new StreamWriter(req.GetRequestStream());
					if (sPostData.Count() % 2 == 0)
					{
						// There is an even number of post names and values
						for (Int32 i = 0; i <= sPostData.Count() - 1; i += 2)
						{
							// Put the post data together into one string
							sPostDataValue += sPostData[i] + "=" + sPostData[i + 1] + "&";
						}
						sPostDataValue = sPostDataValue.Substring(0, sPostDataValue.Length - 1); // This will remove the extra "&" at the end that was added from the for loop above
						
						// Post the data to the server
						str.Write(sPostDataValue);
						str.Close();
						// Get the response
						nInitialCookieCount = req.CookieContainer.Count;
						resp = (HttpWebResponse)req.GetResponse();
						if (req.CookieContainer.Count > nInitialCookieCount)
						{
							// Login successful
							// Save new login cookies
							SaveCookies(req.CookieContainer);
							bReturn = true;
							// At this point you are already logged in and cookies have been saved so any code after this is unnecessary unless you want to double-check the source code
							resp = (HttpWebResponse)req.GetResponse(); // Get the response from the server 
							StreamReader stw = new StreamReader(resp.GetResponseStream());
							string sSourcePage = stw.ReadToEnd(); // Read the response from the server, but dont save it
							System.IO.File.WriteAllText("testp.txt", sSourcePage);
							System.Windows.Forms.MessageBox.Show("Loaded");
							if (sSourcePage.Contains("<span style=\"color: #888\">Hi</span>"))
							{
								System.Windows.Forms.MessageBox.Show("Success");
							}
						}
						else
						{
							MessageBox.Show("The email or password you entered are incorrect." + System.Environment.NewLine + System.Environment.NewLine + "Please try again.", "Unable to log in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							bReturn = false;
						}
					}
					else
					{
						// Did not specify the correct amount of parameters so we cannot continue
						MessageBox.Show("POST error.  Did not supply the correct amount of post data for " + sPage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						bReturn = false;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("POST error.  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					bReturn = false;
				}
				return bReturn;
			}
			private System.Net.CookieContainer SetCookieContainer(string sPage)
			{
				System.Net.CookieContainer oCookieContainerObject = new System.Net.CookieContainer();
				System.Net.Cookie oCookie = default(System.Net.Cookie);
				for (Int32 c = 0; c <= oCookieCollection.Count - 1; c++)
				{
					oCookie = new System.Net.Cookie();
					oCookie.Name = oCookieCollection[c].Name;
					oCookie.Value = oCookieCollection[c].Value;
					oCookie.Domain = new Uri(sPage).Host;
					oCookie.Secure = false;
					oCookieContainerObject.Add(oCookie);
				}
				return oCookieContainerObject;
			}
			private void SaveCookies(string sCookieString)
			{
				// Remove commas in the expires date first so that we can properly parse the cookie string
				Int32 nIndex1 = sCookieString.IndexOf("expires=");
				Int32 nIndex2 = -1;
				while (!(nIndex1 == -1))
				{
					nIndex2 = sCookieString.IndexOf(";", nIndex1);
					if (nIndex2 > -1)
					{
						sCookieString = sCookieString.Substring(0, nIndex1) + sCookieString.Substring(nIndex1, nIndex2 - nIndex1).Replace(",", "") + sCookieString.Substring(nIndex2, sCookieString.Length - nIndex2);
					}
					nIndex1 = sCookieString.IndexOf("expires=", nIndex2);
				}
				// Convert cookie string to global cookie collection object
				string[] sCookieStrings = sCookieString.Trim().Split(",".ToCharArray());
				oCookieCollection = new CookieCollection();
				foreach (string sCookie in sCookieStrings)
				{
					string[] sCookieStringSeparated = sCookie.Trim().Split(";".ToCharArray());
					if (!string.IsNullOrEmpty(sCookieStringSeparated[0].Trim()))
					{
						string sName = sCookieStringSeparated[0].Trim().Split('=')[0];
						string sValue = sCookieStringSeparated[0].Trim().Split('=')[1];
						oCookieCollection.Add(new Cookie(sName, sValue));
					}
				}
			}
			private void SaveCookies(CookieContainer oCookieContainer)
			{
				// Convert cookie container object to global cookie collection object
				oCookieCollection = new CookieCollection();
				foreach (System.Net.Cookie oCookie in oCookieContainer.GetCookies(new Uri(sMainURL)))
				{
					oCookieCollection.Add(oCookie);
				}
			}
			private string UrlEncode(string URLText)
			{
				int AscCode = 0;
				string EncText = "";
				byte[] bStr = System.Text.Encoding.ASCII.GetBytes(URLText);
				try
				{
					for (int i = 0; i < bStr.Count(); i++)
					{
						AscCode = bStr[i];
						switch (AscCode)
						{
							case 46:
							case 48:
							case 49:
							case 50:
							case 51:
							case 52:
							case 53:
							case 54:
							case 55:
							case 56:
							case 57:
							case 65:
							case 66:
							case 67:
							case 68:
							case 69:
							case 70:
							case 71:
							case 72:
							case 73:
							case 74:
							case 75:
							case 76:
							case 77:
							case 78:
							case 79:
							case 80:
							case 81:
							case 82:
							case 83:
							case 84:
							case 85:
							case 86:
							case 87:
							case 88:
							case 89:
							case 90:
							case 95:
							case 97:
							case 98:
							case 99:
							case 100:
							case 101:
							case 102:
							case 103:
							case 104:
							case 105:
							case 106:
							case 107:
							case 108:
							case 109:
							case 110:
							case 111:
							case 112:
							case 113:
							case 114:
							case 115:
							case 116:
							case 117:
							case 118:
							case 119:
							case 120:
							case 121:
							case 122:
								EncText = EncText + (char)AscCode;
								break;
							case 32:
								EncText = EncText + "+";
								break;
							default:
								if (AscCode < 16)
								{
									EncText = EncText + "%0" + AscCode.ToString("X");
								}
								else
								{
									EncText = EncText + "%" + AscCode.ToString("X");
								}
								break;
						}
					}
					bStr = null;
				}
				catch (WebException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return EncText;
			}
		}
	}
