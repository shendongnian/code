	private System.Drawing.Image GetImageFromUrl(string url)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
		using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
		{
			using (Stream stream = httpWebReponse.GetResponseStream())
			{
				return System.Drawing.Image.FromStream(stream);
			}
		}
	}
