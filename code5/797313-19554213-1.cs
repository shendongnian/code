    //Code for host
    case (GameState.PlayingAsHost):
    {
      session.Update();
    
      while (session.LocalGamers[0].IsDataAvailable) //Recieve data
      {
         NetworkGamer sender;
         PacketReader reader = new PacketReader();
    
         session.LocalGamers[0].ReceiveData(reader, out sender);
    
         guestPaddle.Position = reader.ReadVector2();
      }
    
      hostPaddle.Update();
    
      var packetWriter = new PacketWriter(); //Send data
      packetWriter.Write(new Vector2(hostPaddle.Position.X, 50));
      session.LocalGamers[0].SendData(packetWriter,SendDataOptions.InOrder);
    }
    
    //Guest Code
    case (GameState.PlayingAsGuest):
    {
      session.Update();
    
      while (session.LocalGamers[0].IsDataAvailable)//Recieve data
      {
         NetworkGamer sender;
         PacketReader reader = new PacketReader();
    
         session.LocalGamers[0].ReceiveData(reader, out sender);
    
         hostPaddle.Position = reader.ReadVector2();
      }
    
      guestPaddle.Update();
    
      var packetWriter = new PacketWriter(); //Send data
      packetWriter.Write(new Vector2(guestPaddle.Position.X, 50));
      session.LocalGamers[0].SendData(packetWriter, SendDataOptions.InOrder);
    }
