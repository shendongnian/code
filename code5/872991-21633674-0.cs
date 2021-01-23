     protected override async void OnStart(string[] args)
            {
                eventLog1.WriteEntry("In OnStart");
                try
                {
                    var hubConnection = new HubConnection("http://localhost/AlphaFrontEndService/signalr", useDefaultUrl: false);
                    IHubProxy alphaProxy = hubConnection.CreateHubProxy("AlphaHub");
                    
                    await hubConnection.Start();
                    // Invoke method on hub
                    await alphaProxy.Invoke("Hello", "Message from Service");
    
                }
                catch (Exception ex)
                {
                    eventLog1.WriteEntry(ex.Message);
                }
            }
