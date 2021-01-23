            try
            {
                HttpWebRequest _request = _httpUrl;
                _request.Method = "GET";
                
                if (_httpProxy != null)
                {
                    _request.Proxy = _httpProxy;
                    proxymessage = "with Proxy";
                }
                else
                    proxymessage = "without Proxy";
                _response = (HttpWebResponse)_request.GetResponse();
                _strBuilderVerbose.Append(String.Format("HttpWebRequest {0} was successful",proxymessage));
                return true;
            }
            catch (WebException e)
            {
                _strBuilderVerbose.Append(String.Format("Catch 'WebException e' {0} was called",proxymessage));
                if (e.Status == WebExceptionStatus.ProtocolError) _response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (_response != null) _response.Close();
                return false;
            }
            return true;
        }
