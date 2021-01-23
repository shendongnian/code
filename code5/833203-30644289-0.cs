        catch(WebException ex)
		{
			string fullExStack = ex.ToString();
			if(String.Compare(fullExStack, "System.IO.IOException: The authentication or decryption has failed.", true) == 0
				|| String.Compare(fullExStack, "Mono.Security.Protocol.Tls.TlsException: Invalid certificate received from server.", true) == 0)
			{
				// Do Anything you need here
				// like throwing a custom exception
			}
		}
