    **you can try this may help you**
    
    
        public void close()
    		{
    			if(clientSocket != null )
    			{
    				sendCommand("QUIT");
    			}
    
    			cleanup();
    			
    		}
    
        private void cleanup()
    		{
    			if(clientSocket!=null)
    			{
    				clientSocket.Close();
    				clientSocket = null;
    			}
    			logined = false;
    		}
