		public async static Task<string> DownloadImage(string fileWebAddress, string localPath)
		{
			await new WebClient ().DownloadFileTaskAsync (url, fileName);
            return localPath;
		}
