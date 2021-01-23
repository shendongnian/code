    BlockingCollection<object[]> sendBuffer = new BlockingCollection<object[]>();
    // CancellationTokenSource is used in place of your run variable.
    System.Threading.CancellationTokenSource cancellationSource 
    = new System.Threading.CancellationTokenSource();
		private void Sender()
		{
            // Exit loop if cancellation requested
			while (!cancellationSource.Token.IsCancellationRequested)
			{
				object[] obj;
				try {
					// Blocks until an item is available in sendBuffer or cancellationSource.Cancel() is called.
					obj = sendBuffer.Take(cancellationSource.Token);
				} catch (OperationCanceledException) {
					// OperationCanceledException will be thrown if cancellationSource.Cancel() 
					// is called during call to sendBuffer.Take
					break;
				} catch (InvalidOperationException) {
					// An InvalidOperationException means that Take() was called on a completed collection.
					// See BlockingCollection<T>.CompleteAdding
					break;
				}
				string IP = obj[0].ToString();
				string msg = obj[1].ToString();
				byte[] data = Encoding.UTF8.GetBytes(msg);
				foreach (TcpClient tcpc in TcpClients) {
					if ((tcpc.Client.RemoteEndPoint as IPEndPoint).Address.ToString() == IP) {
						NetworkStream stream = tcpc.GetStream();
						stream.Write(data, 0, data.Length);
						break;
					}
				}				
			}
		} 
  
