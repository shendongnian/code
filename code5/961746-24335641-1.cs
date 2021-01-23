	public static class AsyncHttpRequest
	{
		public static void Send(string url)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.KeepAlive = false;
				ThreadPool.QueueUserWorkItem(
					o =>
					{
						var response = request.GetResponse();
						response.Close();
					});
			}
			catch (Exception ex)
			{
				Errors.ErrorSignal.SignalError(ex);
			}
		}
		public static void Send(string url, Action<HttpWebResponse> callback)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.KeepAlive = false;
				ThreadPool.QueueUserWorkItem(
					o =>
					{
						var response = request.GetResponse();
						callback(response)
						response.Close();
						
					});
			}
			catch (Exception ex)
			{
				Errors.ErrorSignal.SignalError(ex);
			}
		}
	}
