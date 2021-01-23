		public async Task<string> Login(string username, string password)
		{
			HttpWebRequest request = new HttpWebRequest(new Uri(String.Format("{0}Token", "http://***.net/")));
			request.Method = "POST";
			string postString = String.Format("username={0}&password={1}&grant_type=password", HttpUtility.HtmlEncode(username), HttpUtility.HtmlEncode(password));
			byte[] bytes = Encoding.UTF8.GetBytes(postString);
			using (Stream requestStream = await request.GetRequestStreamAsync())
			{
				requestStream.Write(bytes, 0, bytes.Length);
			}
			try
			{
				HttpWebResponse httpResponse =  (HttpWebResponse)(await request.GetResponseAsync());
				string json;
				using (Stream responseStream = httpResponse.GetResponseStream())
				{
					json = new StreamReader(responseStream).ReadToEnd();
					Console.WriteLine(json);
				}
				TokenResponseModel tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(json);
				return tokenResponse.AccessToken;
			}
			catch (Exception ex)
			{
				Console.WriteLine ("h..........." + ex);
				//throw new SecurityException("Bad ls", ex);
				return null;
			}
		}
