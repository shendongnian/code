    TcpClient conn = new TcpClient();
    Stream stream;                    // read and write data to stream
    try
    {
       string msg = "this is a test";
       conn.Connect("localhost", 50000);
       stream = conn.GetStream();
       byte[] by = Encoding.UTF8.GetBytes(msg.ToCharArray(), 0, msg.Length);
       await stream.WriteAsync(by, 0, by.Length);     // write bytes to buffer
       stream.Flush();                                // send bytes, clear buffer
       by = new byte[2048];  // new byte array to store received data
       //wait until buffer has data, then returns buffer length
       int bytesAvailable = await stream.ReadAsync(by, 0, 2048);
       msg = Encoding.UTF8.GetString(by, 0, bytesAvailable);
    } catch (Exception e) { //output exception
    }
