                try
            {
                ViewProgressbar("Try to connect mail-server...", progressBar1.Value = 20);
                string host = dsProvider.Rows[y]["POP_hostOut"].ToString();
                int port = int.Parse(dsProvider.Rows[y]["POP_portOut"].ToString());  //587
                string[] email = von1.Split('@');
                string userName = (dsProvider.Rows[y]["login"].ToString() == "email[0]@email[1]")? email[0]+"@"+email[1] : email[0];
                string password = layer.getUserPassword(listSender.SelectedValue.ToString());
                SmtpClient client = new SmtpClient(host, port);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //A idea from MSDN but it not works. You got the "The server response was: 5.5.1 Authentication Required."
                //System.Net.NetworkCredential myCreds = new System.Net.NetworkCredential(userName, password, host);
                //System.Net.CredentialCache cache = new System.Net.CredentialCache();
                //cache.Add(host, port, "NTLM", myCreds);
                ///cache.GetCredential(host, port, "NTLM");   //NTLM
                client.Credentials = new System.Net.NetworkCredential(userName, password);
                client.Host = host;
                client.Port = port;
                client.EnableSsl = true;
			    client.Send(message);
                ViewProgressbar();
            }
            catch (SmtpException ex)...
