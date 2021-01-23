	private bool ExecuteCommand()
    {
		bool resp ;
		
		_response = null;
		try
		{
			HttpWebRequest _request = _httpUrl;
			_request.Method = "GET";
			if (_httpProxy != null)
			{		
				_request.Proxy = _httpProxy;
			}
			_response = (HttpWebResponse)_request.GetResponse();
			_strBuilderVerbose.Append(String.Format("HttpWebRequest was successful"));
			resp = true ;
		}
		catch (WebException e)
		{
			_strBuilderVerbose.Append(String.Format("Catch 'WebException e' "));
		
			if (e.Status == WebExceptionStatus.ProtocolError)
			{				
				_response = (HttpWebResponse)e.Response;
			}
			else 
			{
				resp = false;
			}
		}
		catch (Exception)
		{
			if (_response != null) 
			{
				_response.Close();
			}
			resp =  false;
		}
		
		return resp ;
	}
