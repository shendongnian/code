                Invoke(
                      new SetTextDeleg(machineExe ),
                      new object[] { macid  });
                macid  = "";
            }
            private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
    
                string str1;
                macid += serialPort1.ReadExisting();
    
                if (macid.Length == 12)
                {
                    macid = macid.Substring(0, 10);
                    Thread t = new Thread(new ThreadStart(DoWork));
                    t.Start();
                }
            }
    
             public void machineExe(string text)
              {
                TextBox1.Text=text;
              }
