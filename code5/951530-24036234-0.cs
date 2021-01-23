    // Connect to a remote device.
        try {
            // Establish the remote endpoint for the socket.
            // ip adress : xx.xx.xx.xxx
            IPHostEntry ipHostInfo = Dns.GetHostEntry(IPAddress.Parse("xx.xx.xx.xxx"));
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            // Create a TCP/IP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            currentsocket = client;
            // Send test data to the remote device.
            //Send(client,"This is a test<EOF>");
            //sendDone.WaitOne();
            // Connect to the remote endpoint.
            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();
            Thread.sleep(250);
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                ((MainWindow)Application.Current.MainWindow).socketconnected = true;
                ((MainWindow)Application.Current.MainWindow).loadingimage.Visibility = Visibility.Hidden;
                ((MainWindow)Application.Current.MainWindow).statuslabel.Content = "Connected";
                ((MainWindow)Application.Current.MainWindow).statuslabel.Foreground = System.Windows.Media.Brushes.Green;
            }));
