        public void StartServer()
        {
            MyHub.Owner = _owner;
            try
            {
                SignalR = WebApp.Start(_serverUri);
            }
            catch (TargetInvocationException e)
            {
                _isServerStarted = false;
                _owner.GetData("Connection", "Error starting server: " + e.Message);
                return;
            }
            catch (Exception e)
            {
                _isServerStarted = false;
                _owner.GetData("Connection", "Error starting server: " + e.Message);
                return;
            }
            _owner.GetData("Connection", "Successful");
            _isServerStarted = true;
        }
