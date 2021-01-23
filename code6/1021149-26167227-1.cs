	private void ReadCallback(IAsyncResult ar)
	{
		StateObject tempState = (StateObject) ar.AsyncState;
		Socket handler = tempState.workSocket;
		int bytesRead = handler.EndReceive(ar);
		if (bytesRead <= 0)
		{
			return;
		}
		using (var memoryStream = new MemoryStream(tempState.buffer))
		{
			using (BinaryReader reader = new BinaryReader(memoryStream))
			{
				var filename = reader.ReadString();
				var length = reader.ReadInt32();
				var md5Hash = reader.ReadString();
				var fileData = new byte[memoryStream.Length - memoryStream.Position];
				reader.Read(fileData, 0, fileData.Length);
				try
				{
					using (var writer = new BinaryWriter(
						File.Open(receivePath, FileMode.Append)))
					{
						writer.Write(tempState.buffer, 0, bytesRead);
					}
				}
				catch (Exception error)
				{
					Console.WriteLine(error.Message);
					Thread.Sleep(30);
				}
				finally
				{
					// this method starts a new  AsyncCallback(ReadCallback)
					// and this method is ReadCallback so it works as a recursive method
					handler.BeginReceive(tempState.buffer,
						0,
						StateObject.BufferSize,
						0,
						new AsyncCallback(ReadCallback),
						tempState);
				}
			}
		}
	}
