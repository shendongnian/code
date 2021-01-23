        public static void Main(string[] args)
		{
			using (WebClient client = new WebClient())
			{
				client.DownloadStringCompleted += client_DownloadStringCompleted;
				client.DownloadStringAsync(new Uri("http://www.google.com"));
			}
		}
		private static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			changelogLabel.Text = e.Result.ToString();
		}
