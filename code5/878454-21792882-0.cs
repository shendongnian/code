     var hubConnection = new HubConnection("http://localhost/AlphaFrontEndService/");
     IHubProxy alphaProxy = hubConnection.CreateHubProxy("AlphaHub");
     alphaProxy.On<string>("CallForReport", CallFromReport);
     await hubConnection.Start();
     // ...
