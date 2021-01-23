    if (e.Error is System.Net.WebException)
	{
		var webException = (System.Net.WebException)e.Error;
		var response = (System.Net.HttpWebResponse)webException.Response;
		System.Net.HttpStatusCode status = response.StatusCode;
	}
