     Task connect = s.ConnectTaskAsync( "127.0.0.1" , 443);
     connect.Wait(); // you have to connect before trying to send
     Task sendData = s.SendTaskAsync(Encoding.UTF8.GetBytes("hello"));
     sendData.Wait(); // wait for the data to be sent before calling s.Close()
     s.Close();
