    While (soc.Connected)
    {
        byte[] byData = new byte[2];
        byData = System.Text.Encoding.ASCII.GetBytes("A");
        lock(soc) 
        {
            soc.Send(BitConverter.GetBytes(byData.Length));
            soc.Send(byData);
        }
        Thread.Sleep(0);
    }
