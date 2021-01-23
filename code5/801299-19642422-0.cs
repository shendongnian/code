    var result = socket.BeginReceive(ntpData, 0, ntpData.Length, SocketFlags.None, null, null);
    var success = result.AsyncWaitHandle.WaitOne(15000);
    if (!success)
    {
        socket.Close();
        throw new ApplicationException("Failed to connect to NTP server within 15 seconds");
    }
