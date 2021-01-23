       private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
          try
                    {
                        lblS1checking.Text = "Checking...";
                        PingReply reply = ping.Send("SERVER NAME", 2000);
                        if (reply.Status == IPStatus.Success)
                        {
                            lblS1check.BackColor = Color.LimeGreen;
                            lblS1check.Text = "UP";
                        }
                        else
                        {
                            lblS1check.BackColor = Color.Red;
                            lblS1check.Text = "DOWN";
                        }
        
                    }
                    catch (PingException ex)
                    {
                        MessageBox.Show("Failed!");
        
                    }
                    lblS1checking.Text = "Done.";
                }
        }
