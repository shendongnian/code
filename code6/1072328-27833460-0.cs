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
				Int32 nTimeout = 30;
				string sURL = "http://emaps.emapsplus.com/rdl/MadisonCoAl/MadisonCoAl.aspx?showimg=yes&pid=1701013003029000";
				HttpWebRequest oRequest = HttpWebRequest.Create(new Uri(sURL).AbsoluteUri) as HttpWebRequest;
				string sPostData = "__EVENTTARGET=btnPageLoad&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUKLTQ1NTI3MTY5MA9kFgICAw9kFgICBw9kFgICCQ8UKwAFDxYCHg5SZW5kZXJpbmdTdGF0ZQsplgFNaWNyb3NvZnQuUmVwb3J0aW5nLldlYkZvcm1zLlJlcG9ydFJlbmRlcmluZ1N0YXRlLCBNaWNyb3NvZnQuUmVwb3J0Vmlld2VyLldlYkZvcm1zLCBWZXJzaW9uPTEwLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EBZCgpWFN5c3RlbS5HdWlkLCBtc2NvcmxpYiwgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODkkOWJkMmMyNTAtMGMyMi00NTlhLWFkODQtNmQ3MjZhNzVkMmE1AgEUKwABPCsABAEAZmQWAgIBD2QWAmYPZBYCZg9kFgwCAQ8PFgIeB1Zpc2libGVoZBYEAgMPZBYCAgEPDxYCHgRUZXh0BfYBaHR0cDovL2VtYXBzLmVtYXBzcGx1cy5jb20vQXJjR0lTL3Jlc3Qvc2VydmljZXMvQUwvQUxNYWRpc29uL01hcFNlcnZlci9leHBvcnQ%2Fc2l6ZT0yMzQlMkMyMzQmYmJveFNSPTEwMjEwMCZmPWltYWdlJmltYWdlU1I9MTAyMTAwJmRwaT05NiZ0cmFuc3BhcmVudD10cnVlJmZvcm1hdD1wbmc4JmJib3g9LTk2MTk0MTYuNzExMjg0NTUlMkM0MTIxMjUyLjczNDY0ODI1JTJDLTk2MTg5MzguNDU1NTMzMDglMkM0MTIxMzg0LjA1NzI3ODAxZGQCBQ9kFgICAQ8PFgIfAgX8AWh0dHA6Ly9iZXRhLmVtYXBzcGx1cy5jb20vQXJjR0lTL3Jlc3Qvc2VydmljZXMvQUwvQUxNYWRpc29uL0ltYWdlU2VydmVyL2V4cG9ydEltYWdlP3NpemU9MjM0JTJDMjM0JmJib3hTUj0xMDIxMDAmZj1pbWFnZSZpbWFnZVNSPTEwMjEwMCZkcGk9OTYmdHJhbnNwYXJlbnQ9dHJ1ZSZmb3JtYXQ9cG5nOCZiYm94PS05NjE5NDE2LjcxMTI4NDU1JTJDNDEyMTI1Mi43MzQ2NDgyNSUyQy05NjE4OTM4LjQ1NTUzMzA4JTJDNDEyMTM4NC4wNTcyNzgwMWRkAgIPZBYCAgIPFgIeBVZhbHVlBQVmYWxzZWQCAw9kFgJmD2QWAmYPDxYCHwFoZGQCBQ9kFgICAg8WAh8DBQVmYWxzZWQCBg9kFgJmD2QWAmYPZBYEZg8PZBYCHgVzdHlsZQUQdmlzaWJpbGl0eTpub25lO2QCAw9kFgQCAQ8WAh4HRW5hYmxlZGhkAgQPFgIfAwUDMTAwZAIKD2QWAgIBDxYCHwMFBUZhbHNlZBgBBR5fX0NvbnRyb2xzUmVxdWlyZVBvc3RCYWNrS2V5X18WAgUdUmVwb3J0Vmlld2VyMSRUb2dnbGVQYXJhbSRpbWcFF1JlcG9ydFZpZXdlcjEkY3RsMDgkaW1nROgsNj0tGADUWq38Qh5RMY%2BnFOA%3D&__EVENTVALIDATION=%2FwEWFAKdu8DBDgKDxYqfDgK6xP6gCgKMibrFCwKNibrFCwL7tKb%2BBwLM8P%2B9BgLPuvOLBQLW3c2kCQLe9c6iAwKOr4XtBAL13tfgBwLPoojEDgKzk7fEDALe0J%2FBAgKEzI3pBQK46LajBwLFj9iUDALg%2BPWpBgLnhouUCc0tnKuBes2OqgW72h2Q9urEYxX2&hdnLoaded=false&ReportViewer1%24ctl03%24ctl00=&ReportViewer1%24ctl03%24ctl01=&ReportViewer1%24ctl11=&ReportViewer1%24ctl12=standards&ReportViewer1%24AsyncWait%24HiddenCancelField=False&ReportViewer1%24ToggleParam%24store=&ReportViewer1%24ToggleParam%24collapse=false&ReportViewer1%24ctl09%24ClientClickedId=&ReportViewer1%24ctl08%24store=&ReportViewer1%24ctl08%24collapse=false&ReportViewer1%24ctl10%24VisibilityState%24ctl00=Error&ReportViewer1%24ctl10%24ScrollPosition=&ReportViewer1%24ctl10%24ReportControl%24ctl02=&ReportViewer1%24ctl10%24ReportControl%24ctl03=&ReportViewer1%24ctl10%24ReportControl%24ctl04=100";
				byte[] oPostDataBuffer = System.Text.Encoding.ASCII.GetBytes(sPostData);
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
			}
		}
	}
