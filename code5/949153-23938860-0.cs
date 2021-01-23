        Log("Getter Fired");
        //var message = GSM.ReadMessage(4);
        //GSM.ReadMessage(4);
        //TcpClientChannel client = new TcpClientChannel();
        //ChannelServices.RegisterChannel(client, false);
        //string url = "*******";
        //ISmsSender smssender = (ISmsSender)Activator.GetObject(typeof(ISmsSender), url);
               try
            {
                DecodedShortMessage[] messages = Comm.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Sim);
                SqlConnection Conn = new SqlConnection("Data Source=*********;Initial Catalog=********;User ID=**********;Password=***********");
                SqlCommand com = new SqlCommand();
                com.Connection = Conn;
                Conn.Open();
                com.CommandText = ("INSERT INTO SMSArchives(Message,Blacklist) VALUES (@par1,@par2)");
                com.Parameters.Add("@par1");
                com.Parameters.Add("@par2");
                foreach (DecodedShortMessage message in messages)
                {
                    com.ExecuteNonQuery(message.Data.UserDataText,"yes");
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }
