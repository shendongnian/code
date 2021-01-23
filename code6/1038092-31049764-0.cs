    //Send ( button_click )
            string from = "9199********";
            string to = txtTo.Text;//Sender Mobile
            string msg = txtMessage.Text;
            WhatsApp wa = new WhatsApp(from, "BnXk*******B0=", "NickName", true, true);
            wa.OnConnectSuccess += () =>
            {
                MessageBox.Show("Connected to whatsapp...");
                wa.OnLoginSuccess += (phoneNumber, data) =>
                {
                    wa.SendMessage(to, msg);
                    MessageBox.Show("Message Sent...");
                };
                wa.OnLoginFailed += (data) =>
                {
                    MessageBox.Show("Login Failed : {0}", data); 
                };
                wa.Login();
            };
            wa.OnConnectFailed += (ex) =>
            {
                MessageBox.Show("Connection Failed...");
            };
            wa.Connect();
