        catch(WebException ex)
		{
			string fullExStack = ex.ToString();
            if (fullExStack.Contains(("System.IO.IOException: The authentication or decryption has failed.").ToLower())
                || fullExStack.Contains(("Mono.Security.Protocol.Tls.TlsException: Invalid certificate received from server.").ToLower()))
			{
				// Do Anything you need here
				// like throwing a custom exception
			}
		}
