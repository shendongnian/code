    public static string TryGetPageHtml(string link, int attempCount = 1,
     System.Net.WebProxy proxy = null, string foundHTML = null)
    {
		if(attemptCount == 0 || foundHTML != null)
		{
			return foundHTML;
		}
		
		if (proxy != null)
		{
			client.Proxy = proxy;
		}
		using (System.Net.WebClient client = new System.Net.WebClient())
		{
			client.Encoding = Encoding.UTF8;
			
			try
			{
				foundHTML = client.DownloadString(link);
			}
			catch (Exception ex)
			{
				return null; //Remove this if we want to retry on exception
			}
			finally
			{
				return TryGetPageHtml(link, --attemptCount, proxy, foundHTML);
			}
		}
    }
