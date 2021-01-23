       public void ListenTraces()
        {
            httpListener.Prefixes.Add(PORT_HOST);
            try
            {
                httpListener.Start();
            }
            catch (HttpListenerException hlex)
            {
                log.Warn("Can't start the agent to listen transaction" + hlex);
                return;
            }
            log.Info("Now ready to receive traces...");
            while (true)
            {
                var context = httpListener.GetContext(); // get te context 
          
                log.Info("New trace connexion incoming");
               Console.WriteLine(context.SomethingYouWant);
            }
        }
