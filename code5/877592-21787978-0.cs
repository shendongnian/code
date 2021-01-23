	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Text;
	using System.Threading.Tasks;
	namespace DracWake.Core
	{
		public class WebClient : IWebClient
		{
			private readonly CookieContainer _cookies = new CookieContainer();
			private HttpWebRequest CreateRequest(Uri uri)
			{
				var request = HttpWebRequest.CreateHttp(uri);
				request.AllowAutoRedirect = false;
				request.CookieContainer = _cookies;
				SetHeaders(request);
				var defaultValidator = System.Net.ServicePointManager.ServerCertificateValidationCallback;
				request.ServerCertificateValidationCallback =
					(sender, certificate, chain, sslPolicyErrors) =>
						certificate.Subject.Contains("O=DO_NOT_TRUST, OU=Created by http://www.fiddler2.com")
						|| (certificate.Subject == "CN=DRAC5 default certificate, OU=Remote Access Group, O=Dell Inc., L=Round Rock, S=Texas, C=US")
						|| (defaultValidator != null && defaultValidator(request, certificate, chain, sslPolicyErrors));
				return request;
			}
			private async Task<string> DecodeResponse(HttpWebResponse response)
			{
				foreach (System.Net.Cookie cookie in response.Cookies)
				{
					_cookies.Add(new Uri(response.ResponseUri.GetLeftPart(UriPartial.Authority)), cookie);
				}
				if (response.StatusCode == HttpStatusCode.Redirect)
				{
					var location = response.Headers[HttpResponseHeader.Location];
					if (!string.IsNullOrEmpty(location))
						return await Get(new Uri(location));
				}	
				var stream = response.GetResponseStream();
				var buffer = new System.IO.MemoryStream();
				var block = new byte[65536];
				var blockLength = 0;
				do{
					blockLength = stream.Read(block, 0, block.Length);
					buffer.Write(block, 0, blockLength);
				}
				while(blockLength == block.Length);
				return Encoding.UTF8.GetString(buffer.GetBuffer());
			}
			public async Task<string> Get(Uri uri)
			{
				var request = CreateRequest(uri);
				var response = (HttpWebResponse) await request.GetResponseAsync();
				return await DecodeResponse(response);
			}
			private void SetHeaders(HttpWebRequest request)
			{
				request.Accept = "text/html, application/xhtml+xml, */*";
				request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
				request.ContentType = "application/x-www-form-urlencoded";
				request.Headers[HttpRequestHeader.AcceptLanguage] = "en-US,en;q=0.8,de-DE;q=0.5,de;q=0.3";
				request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
				request.Headers[HttpRequestHeader.CacheControl] = "no-cache";
			}
			public async Task<string> Post(Uri uri, byte[] data)
			{
				var request = CreateRequest(uri);
				request.Method = "POST";
				request.GetRequestStream().Write(data, 0, data.Length);
				var response = (HttpWebResponse) await request.GetResponseAsync();
				return await DecodeResponse(response);
			}
		}
	}
