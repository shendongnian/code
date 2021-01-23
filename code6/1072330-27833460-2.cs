		using System;
		using System.Collections.Generic;
		using System.ComponentModel;
		using System.Data;
		using System.Drawing;
		using System.IO;
		using System.Linq;
		using System.Net;
		using System.Text;
		using System.Threading.Tasks;
		using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				string sURL = "http://emaps.emapsplus.com/rdl/MadisonCoAl/MadisonCoAl.aspx?showimg=yes&pid=1701013003029000";
				string sSource = "";
				byte[] buffer = new byte[4096];
				WebRequest wr = WebRequest.Create(sURL);
				using (WebResponse response = wr.GetResponse())
				{
					using (Stream responseStream = response.GetResponseStream())
					{
						using (MemoryStream memoryStream = new MemoryStream())
						{
							int count = 0;
							do
							{
								count = responseStream.Read(buffer, 0, buffer.Length);
								memoryStream.Write(buffer, 0, count);
							} while (count != 0);
							sSource = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
						}
					}
				}
				if (!string.IsNullOrEmpty(sSource))
				{
					const string sQuoteString = "\"";   // If the values are not being found it could be because the markup is being output with single quotes change this variable from "\"" to "'" in that case
					const string sViewStateString = "__VIEWSTATE";
					const string sEventValidationString = "__EVENTVALIDATION";
					const string sValueString = "value=" + sQuoteString;
					Int32 nIndex1 = sSource.IndexOf(sViewStateString);
					Int32 nIndex2 = default(Int32);
					bool bFoundValues = false;
					string sViewState = "";
					string sEventValidation = "";
					// Look for the view state and event validation tags and grab the values
					// Without these values we cannot continue
					if (nIndex1 > -1)
					{
						nIndex2 = sSource.IndexOf(sValueString, nIndex1);
						if (nIndex2 > -1)
						{
							nIndex1 = sSource.IndexOf(sQuoteString, nIndex2 + sValueString.Length);
							if (nIndex1 > -1)
							{
								sViewState = sSource.Substring(nIndex2 + sValueString.Length, nIndex1 - nIndex2 - sValueString.Length);
								nIndex1 = sSource.IndexOf(sEventValidationString);
								if (nIndex1 > -1)
								{
									nIndex2 = sSource.IndexOf(sValueString, nIndex1);
									if (nIndex2 > -1)
									{
										nIndex1 = sSource.IndexOf(sQuoteString, nIndex2 + sValueString.Length);
										if (nIndex1 > -1)
										{
											sEventValidation = sSource.Substring(nIndex2 + sValueString.Length, nIndex1 - nIndex2 - sValueString.Length);
											bFoundValues = true;
										}
									}
								}
							}
						}
					}
					if (bFoundValues == true)
					{
						Int32 nTimeout = 30;
						HttpWebRequest oRequest = HttpWebRequest.Create(new Uri(sURL).AbsoluteUri) as HttpWebRequest;
						string sPostData = "__EVENTTARGET=btnPageLoad&__EVENTARGUMENT=&__VIEWSTATE=" + System.Web.HttpUtility.UrlEncode(sViewState) + "&__EVENTVALIDATION=" + System.Web.HttpUtility.UrlEncode(sEventValidation) + "&hdnLoaded=false&ReportViewer1%24ctl03%24ctl00=&ReportViewer1%24ctl03%24ctl01=&ReportViewer1%24ctl11=&ReportViewer1%24ctl12=standards&ReportViewer1%24AsyncWait%24HiddenCancelField=False&ReportViewer1%24ToggleParam%24store=&ReportViewer1%24ToggleParam%24collapse=false&ReportViewer1%24ctl09%24ClientClickedId=&ReportViewer1%24ctl08%24store=&ReportViewer1%24ctl08%24collapse=false&ReportViewer1%24ctl10%24VisibilityState%24ctl00=Error&ReportViewer1%24ctl10%24ScrollPosition=&ReportViewer1%24ctl10%24ReportControl%24ctl02=&ReportViewer1%24ctl10%24ReportControl%24ctl03=&ReportViewer1%24ctl10%24ReportControl%24ctl04=100";
						byte[] oPostDataBuffer = System.Text.Encoding.ASCII.GetBytes(sPostData);
						oRequest.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10; rv:33.0) Gecko/20100101 Firefox/33.0";
						oRequest.Timeout = nTimeout * 1000;
						oRequest.Method = "POST";
						oRequest.ContentType = "application/x-www-form-urlencoded";
						oRequest.ContentLength = oPostDataBuffer.Length;
						using (Stream oRequestStream = oRequest.GetRequestStream())
						{
							oRequestStream.Write(oPostDataBuffer, 0, oPostDataBuffer.Length);
							oRequestStream.Close();
						}
						HttpWebResponse oResponse = oRequest.GetResponse() as HttpWebResponse;
						if (oResponse.StatusCode != HttpStatusCode.OK)
						{
							// Error
							MessageBox.Show(oResponse.StatusCode.ToString());
						}
						else
						{
							// Status is OK
							byte[] oBuffer = null;
							byte[] oFile = null;
							using (BinaryReader reader = new BinaryReader(oResponse.GetResponseStream()))
							{
								using (MemoryStream oMemoryStream = new MemoryStream())
								{
									oBuffer = reader.ReadBytes(1024);
									while (oBuffer.Length > 0)
									{
										oMemoryStream.Write(oBuffer, 0, oBuffer.Length);
										oBuffer = reader.ReadBytes(1024);
									}
									oFile = new byte[Convert.ToInt32(Math.Floor(Convert.ToDouble(oMemoryStream.Length)))];
									oMemoryStream.Position = 0;
									oMemoryStream.Read(oFile, 0, oFile.Length);
								}
							}
							using (FileStream oFileStream = new FileStream("C:\\testpdf.pdf", FileMode.Create))
							{
								oFileStream.Write(oFile, 0, oFile.Length);
							}
						}
						MessageBox.Show("PDF downloaded to C:\\testpdf.pdf");
					}
					else
					{
						MessageBox.Show("Cannot find the __VIEWSTATE and/or __EVENTVALIDATION variables.");
					}
				}
				else
				{
					MessageBox.Show("Cannot find source code for original url.");
				}
			}
		}
	}
