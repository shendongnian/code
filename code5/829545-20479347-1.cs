     private async void Connect()
     {
       connection = new HubConnection("http://localhost:2446/");
       hubProxy = connection.CreateHubProxy("ScanHub");
       await connection.Start();
       //If using WPF you can test like so if not use whatever output method you prefer to see if it connects
       if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
       {
                MessageBox.Show("Connected!");
       }
       else
       {
                MessageBox.Show("Fail!");
       }
     }
