    public override void Close()
    		{
    			if (Logging.On)
    			{
    				Logging.Enter(Logging.Web, this, "Close", "");
    			}
    			if (this.HttpProxyMode)
    			{
    				this.m_HttpWebResponse.Close();
    			}
    			else
    			{
    				Stream responseStream = this.m_ResponseStream;
    				if (responseStream != null)
    				{
    					responseStream.Close();
    				}
    			}
    			if (Logging.On)
    			{
    				Logging.Exit(Logging.Web, this, "Close", "");
    			}
    		}
