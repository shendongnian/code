    private bool ExecuteCommand()
    {
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
	  _strBuilderVerbose.Append(String.Format("HttpWebRequest with Proxy was successful"));
	  return true;
       }
       catch (WebException e)
       {
	  _strBuilderVerbose.Append(String.Format("Catch 'WebException e' "));
	  if (e.Status == WebExceptionStatus.ProtocolError) 
             _response = (HttpWebResponse)e.Response;
	  else 
             return false;
       }
       catch (Exception)
       {
          if (_response != null) 
             _response.Close();
	  return false;
       }
    }
