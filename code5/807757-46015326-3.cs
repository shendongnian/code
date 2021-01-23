      private void Start_Receiving_Video_Conference()
        {
            try
            {
                // Open The Port
                mytcpl = new TcpListener(5000);
                mytcpl.Start();						 // Start Listening on That Port
                mysocket = mytcpl.AcceptSocket();		 // Accept Any Request From Client and Start a Session
                ns = new NetworkStream(mysocket);	 // Receives The Binary Data From Port
                picture_comming.Image = Image.FromStream(ns);
                mytcpl.Stop();							 // Close TCP Session
                if (mysocket.Connected == true)		     // Looping While Connected to Receive Another Message 
                {
                    while (true)
                    {
                        Start_Receiving_Video_Conference();				 // Back to First Method
                    }
                }
                myns.Flush();
            }
            catch (Exception) { button1.Enabled = true; myth.Abort(); }
        }
