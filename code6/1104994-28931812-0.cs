    bool isUsed;
    for (int i = 0; i < clientsInfoList.Count && !isUsed; i++)
    {
       isUsed = String.Equals(clientsInfoList[i].Item3, Username);
    }
    
    if (isUsed)
    {
       Console.WriteLine("Username is already used!");
       udpServer.Send(Encoding.ASCII.GetBytes("REFUSED"), Encoding.ASCII.GetByteCount("REFUSED"), remoteEP);
    }
    else
    {
       clientsInfoList.Add(new Tuple<int, IPEndPoint, string>(id, remoteEP, Username));
       Console.WriteLine("Username has been added to the list :)");
       udpServer.Send(Encoding.ASCII.GetBytes("ACCEPTED"), Encoding.ASCII.GetByteCount("ACCEPTED"), remoteEP);
    }
