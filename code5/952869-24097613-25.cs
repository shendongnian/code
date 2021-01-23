    protected void Page_Load(object sender, EventArgs e)
	{
		if ((Session.Contents.Count > 0) && (Session["loginWith"] != null) && (Session["loginWith"].ToString() == "google"))
		{
			try
			{
				var url = Request.Url.Query;
				if (url != "")
				{
					string queryString = url.ToString();
					char[] delimiterChars = { '=' };
					string[] words = queryString.Split(delimiterChars);
					string code = words[1];
					if (code != null)
					{
						//get the access token 
						HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
						webRequest.Method = "POST";
						Parameters = "code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_secret + "&redirect_uri=" + googleplus_redirect_url + "&grant_type=authorization_code";
						byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
						webRequest.ContentType = "application/x-www-form-urlencoded";
						webRequest.ContentLength = byteArray.Length;
						Stream postStream = webRequest.GetRequestStream();
						// Add the post data to the web request
						postStream.Write(byteArray, 0, byteArray.Length);
						postStream.Close();
						WebResponse response = webRequest.GetResponse();
						postStream = response.GetResponseStream();
						StreamReader reader = new StreamReader(postStream);
						string responseFromServer = reader.ReadToEnd();
						GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);
						if (serStatus != null)
						{
							string accessToken = string.Empty;
							accessToken = serStatus.access_token;
							if (!string.IsNullOrEmpty(accessToken))
							{
								// This is where you want to add the code if login is successful.
								// getgoogleplususerdataSer(accessToken);
							}
						}
						
					}
				}
			}
			catch (Exception ex)
			{
				//throw new Exception(ex.Message, ex);
				Response.Redirect("index.aspx");
			}
		}
	}
