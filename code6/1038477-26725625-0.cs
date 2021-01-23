    using (TcpClient client = new TcpClient (/IP ADDRESS/, /PORT/))
			using (NetworkStream stream = client.GetStream ())
			using (StreamReader reader = new StreamReader (stream))
			using (StreamWriter writer = new StreamWriter (stream)) {
				writer.AutoFlush = true;
				foreach (string lineToSend in linesToSend) {
					Console.WriteLine ("Sending to server: {0}", lineToSend);
					writer.WriteLine (lineToSend);
					string lineWeRead = reader.ReadLine ();
					Console.WriteLine ("Received from server: {0}", lineWeRead);
					Thread.Sleep (2000); // just for effect
				}
				Console.WriteLine ("Client is disconnecting from server");
			}
