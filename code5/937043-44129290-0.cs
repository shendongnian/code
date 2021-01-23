                try
                {
                    currPort = Int32.Parse(XSensAvailablePorts[currAttempt]);
                    listener = new UdpClient(currPort);
                    successfullAttempt = true;
                }
                catch (Exception e)
                {
                    currAttempt++;
    
                    if(listener != null)
                    {
                       listener.Close();
                    }
                }
