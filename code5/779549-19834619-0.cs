    void OnApplicationQuit()
	{
	    try
	    {
	        tcp_client.Close();
	        isTrue = false;
	    }
	    catch(Exception e)
	    {
	        Debug.Log(e.Message);
	    }
		
		// You must close the tcp listener
	    try
	    {
			tcp_listener.Stop();
	        isTrue = false;
	    }
	    catch(Exception e)
	    {
	        Debug.Log(e.Message);
	    }
	}
