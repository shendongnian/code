    using System;
    using System.IO;
    using System.Net.Sockets;
    stream = client.GetStream();
    new Thread(() =>
      {
          try
          {
              while ((i = stream.Read(datalength, 0, 4)) != 0)
              {
                  byte[] data = new byte[BitConverter.ToInt32(datalength, 0)];
                  stream.Read(data, 0, data.Length);
                  this.Invoke((MethodInvoker)delegate
                  {
                      txtLog.Text += System.Environment.NewLine + "Server : " + Encoding.Default.GetString(data);
                  });
              }
          }
          catch (IOException ioex)
          {
              if (ioex.InnerException != null)
              {
                  var sex = ex.InnerException as SocketException;
                  if (sex == null)
                  {
                      txtLog.Text += Environment.NewLine + "An unknown exception occurred.";
                  }
                  else
                  {
                      switch (sex.SocketErrorCode)
                      {
                          case SocketError.ConnectionReset:
                              txtLog.Text += Environment.NewLine + "A ConnectionReset SocketException occurred."
                              break;
                          default:
                              txtLog.Text += Environment.NewLine + "A SocketException occurred.";
                              break;
                      }
                  }
              }
              else
              {
                  txtLog.Text += Environment.NewLine + "An IOException occurred.";
              }
          }
      }).Start();
