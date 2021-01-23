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
		
		try {
			FileStream fs = new FileStream(folderPath + "\\AuthService.txt",FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter m_streamwriter = new StreamWriter(fs);
            m_streamwriter.WriteLine(sbCardNo.toString());
		}
		catch (Exception ex)
		{
			//add error handling logic here
		}
		finally
		{
		    m_streamwriter.Flush();
			m_streamwriter.Close();
		}
    }
