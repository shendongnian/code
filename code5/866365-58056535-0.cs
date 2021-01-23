            manager = new ManagerConnection(address, port, user, password);
            manager.UnhandledEvent += new ManagerEventHandler(manager_Events);
            manager.NewState += new NewStateEventHandler(Monitoring_NewState);
            try
            {
                // Uncomment next 2 line comments to Disable timeout (debug mode)
                // manager.DefaultResponseTimeout = 0;
                // manager.DefaultEventTimeout = 0;
                manager.Login();
                if (manager.IsConnected())
                {
                    Console.WriteLine("user name  : " + manager.Username);
                
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connect\n" + ex.Message);
                manager.Logoff();
                Console.ReadLine();
            }
            void manager_Events(object sender, ManagerEvent e)
            {
                Console.WriteLine("Event : " + e.GetType().Name);
            }
               void Monitoring_NewState(object sender, NewStateEvent e)
                  {
                string state = e.State;
                string callerID = e.CallerId;
                Console.WriteLine("caller  num ...", e.CallerIdNum);
                //Console.WriteLine("state =", state);
                //Console.WriteLine("callerID =", callerID);
               
                if ((state == "Ringing") | (e.ChannelState == "5"))
                {
                    Console.WriteLine("hello rining your phone now ...");
                  
                    String connectedLineNum;
                    String connectedLineName;
                    Dictionary<String, String> attributes = e.Attributes;
                    attributes.TryGetValue("connectedlinenum", out connectedLineNum);
                    attributes.TryGetValue("connectedlinename", out connectedLineName);
                    // "callerID" - called phone number
                    // "connectedLineNum" - calling phone number
                 
                    // CallIn. Incoming call
                }
                else if ((state == "Ring") | (e.ChannelState == "4"))
                {
                    Console.WriteLine("hello out going your call ...");
                    // CallOut. Outcoming call
                }
                else if ((state == "Up") | (e.ChannelState == "6"))
                {
                    String connectedLineNum;
                    String connectedLineName;
                    Dictionary<String, String> attributes = e.Attributes;
                    attributes.TryGetValue("connectedlinenum", out connectedLineNum);
                    attributes.TryGetValue("connectedlinename", out connectedLineName);
                    // "callerID" - called phone number
                    // "connectedLineNum" - calling phone number
                    // human lifted up the phone right no
                    Console.WriteLine("human lifted up the phone...");
                    
                }
            }
