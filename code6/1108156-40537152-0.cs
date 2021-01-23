        Dictionary<string, string> mediaParameters = new Dictionary<string, string> ();
				string mediaString = System.Convert.ToBase64String (File.ReadAllBytes (filePath));
				mediaParameters.Add ("media_data", mediaString);
				mediaParameters.Add ("status", text);
				// Add data to the form to post.
				WWWForm mediaForm = new WWWForm ();
				mediaForm.AddField ("media_data", mediaString);
				mediaForm.AddField ("status", text);
    //			Debug.Log (System.Convert.ToBase64String (File.ReadAllBytes (filePath)));
				// HTTP header
				Dictionary<string, string> mediaHeaders = new Dictionary<string, string> ();
				string url = UploadMediaURL;
				string auth = GetHeaderWithAccessToken ("POST", UploadMediaURL, consumerKey, consumerSecret, response, mediaParameters);
				mediaHeaders.Add ("Authorization", auth);
				mediaHeaders.Add ("Content-Transfer-Encoding", "base64");
				WWW mw = new WWW (UploadMediaURL, mediaForm.data, mediaHeaders);
				yield return mw;
					
				string mID = Regex.Match(mw.text, @"(\Dmedia_id\D\W)(\d*)").Groups[2].Value;
				Debug.Log ("response from media request : " + mw.text);
				Debug.Log ("mID = " + mID);
				if (!string.IsNullOrEmpty (mw.error)) {
					Debug.Log (string.Format ("PostTweet - failed. {0}\n{1}", mw.error, mw.text));
					callback (false);
				} else {
					string error = Regex.Match (mw.text, @"<error>([^&]+)</error>").Groups [1].Value;
					if (!string.IsNullOrEmpty (error)) {
						Debug.Log (string.Format ("PostTweet - failed. {0}", error));
						callback (false);
					} else {
						callback (true);
					}
				}
				Dictionary<string, string> parameters = new Dictionary<string, string>();
				parameters.Add("status", text);
				parameters.Add ("media_ids", mID);
				// Add data to the form to post.
				WWWForm form = new WWWForm();
				form.AddField("status", text);
				form.AddField ("media_ids", mID);
				// HTTP header
				var headers = new Dictionary<string, string>();
				headers["Authorization"] = GetHeaderWithAccessToken("POST", PostTweetURL, consumerKey, consumerSecret, response, parameters);
				WWW web = new WWW(PostTweetURL, form.data, headers);
				yield return web;
				if (!string.IsNullOrEmpty(web.error))
				{
					Debug.Log(string.Format("PostTweet - failed. {0}\n{1}", web.error, web.text));
					callback(false);
				}
				else
				{
					string error = Regex.Match(web.text, @"<error>([^&]+)</error>").Groups[1].Value;
					if (!string.IsNullOrEmpty(error))
					{
						Debug.Log(string.Format("PostTweet - failed. {0}", error));
						callback(false);
					}
					else
					{
						callback(true);
					}
				}
