		private void DoWork()
    {
		byte ch ;
        byte[] data = new byte[1024];
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8888);
        UdpClient newsock = new UdpClient(ipep);
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        StringBuilder sbCardNo = new StringBuilder();
		
        do
        {
            data = newsock.Receive(ref sender);
			ch = data.GetValue(0)
            sbCardNo.Append(ch);
        } while (ch != 'Z') ;
		using (StreamWriter m_streamwriter = new StreamWriter( folderPath + "\\AuthService.txt"))
		{
            m_streamwriter.WriteLine(sbCardNo.toString());
		}
    }
