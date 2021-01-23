	void Main()
	{
		var serverIP = "::1";
		var serverPort = 10000;
	
		TCPConnection connection = TCPConnection.GetConnection(new ConnectionInfo(serverIP, serverPort));
		SendReceiveOptions options = connection.ConnectionDefaultSendReceiveOptions.Clone() as SendReceiveOptions;
		options.DataProcessors.Add(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>());
		RijndaelPSKEncrypter.AddPasswordToOptions(options.Options, "Your strong PSK");
		
		if (connection.SendReceiveObject<string>("Payload", "Ack", 1000, 
			new PayloadFile("c:\\CONFIGURACAO.INI")) != null) 
		{
			Console.WriteLine("Done");
		}
	
	}
	[ProtoContract]
	public class PayloadFile
	{
		[ProtoMember(1)]
	    public string FileName { get; set; }
		
		[ProtoMember(2)]
	    public string FileLocation { get; set; }
		
		[ProtoMember(3)]
	    public byte[] FileContent { get; set; }
	
		public PayloadFile()
		{
		}
	
	    public PayloadFile(string FileToLoad)
	    {
	        if (!File.Exists(FileToLoad))
	        {
	            throw new FileNotFoundException();
	        }
	        FileInfo PayloadInfo = new FileInfo(FileToLoad);
	        FileName = PayloadInfo.Name;
	        FileLocation = PayloadInfo.DirectoryName;
	        using (var stream = File.OpenRead(FileToLoad))
			{
				FileContent = unchecked((new BinaryReader(stream)).ReadBytes((int)stream.Length));
			}
	    }
		
	}
	
