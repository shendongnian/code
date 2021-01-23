    byte[] buffer = new byte[255];
    private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
          try
          {
             for (int c = 0; pointer+c < buffer.Length && c < serialPort.BytesToRead; c++)
             {
                buffer[pointer++] = serialPort.ReadByte();
             }
          }
          catch
          {
              MessageBox.Show("Error reading port!");
          }
    }
    .
    .
    .
    //and then you convert what you have read with something like this:
    
    System.Text.Encoding.ASCII.GetString(buffer);
