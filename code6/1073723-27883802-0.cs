    if (stream.DataAvailable)
                        {
                            Task DataInterpetTask = Task.Factory.StartNew(() =>
                            {
                                int totalBuffer, totalRecieved = 0;
                                byte[] totalBufferByte = new byte[4];
                                byte[] buffer = new byte[0];
                                byte[] tbuffer;
                                int rLength, prevLength;
                                byte[] buf = new byte[c.getClientSocket().ReceiveBufferSize];
                                stream.Read(totalBufferByte, 0, 4);
                                totalBuffer = BitConverter.ToInt32(totalBufferByte, 0);
                                totalBuffer = totalBuffer - 3;
                                while (totalBuffer > totalRecieved)
                                {
                                    rLength = stream.Read(buf, 0, buf.Length);
                                    totalRecieved = rLength + totalRecieved;
                                    if (rLength < buf.Length)
                                    {
                                        byte[] temp = new byte[rLength];
                                        Array.Copy(buf, temp, rLength);
                                        buf = temp;
                                    }
                                    prevLength = buffer.Length;
                                    tbuffer = buffer;
                                    buffer = new byte[buffer.Length + rLength];
                                    Array.Copy(tbuffer, buffer, tbuffer.Length);
                                    buf.CopyTo(buffer, prevLength);
                                }
                                String msg = Encoding.ASCII.GetString(buffer);
                                if (msg.Contains("PNG") || msg.Contains("RBG") || msg.Contains("HDR"))
                                {
                                    RowContainer tempContainer;
                                    if ((tempContainer = MainWindow.mainWindow.RowExists(c)) != null)
                                    {
                                        tempContainer.Image = buffer;
                                        MainWindow.mainWindowDispacter.BeginInvoke(new Action(() =>
                                            MainWindow.mainWindow.UpdateRowContainer(tempContainer, 0)));
                                    }
                                    else
                                    {
                                        MainWindow.mainWindowDispacter.BeginInvoke(new Action(() =>
                                           MainWindow.mainWindow.CreateClientRowContainer(c, buffer)));
                                    }
                                    return;
                                }
                                String switchString = msg.Substring(0, 4);
                                if (msg.Length > 4)
                                    msg = msg.Substring(4);
                                MainWindow.mainWindowDispacter.BeginInvoke(new Action(() =>
                                {
                                    if (MainWindow.debugWindow != null)
                                        MainWindow.debugWindow.LogTextBox.AppendText("Received message " + msg + " from client: " + c.getClientIp() + " as a " + switchString + " type" + Environment.NewLine);
                                }));
                                switch (switchString)
                                {
                                    case "pong":
                                        c.RespondedPong();
                                        break;
                                    case "stat":
                                        RowContainer tContain = MainWindow.mainWindow.RowExists(c);
                                        if (tContain == null)
                                            break;
                                        tContain.SetState(msg);
                                        MainWindow.mainWindow.UpdateRowContainer(tContain, 1);
                                        break;
                                }
                            });
                        }
                    }
