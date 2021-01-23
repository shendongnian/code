            Text = Reciever;
 
            await _connection.Start();
            await _myHub.Invoke("Join");
           
            _myHub.On("recieved", data =>
            {
                var obj = JsonConvert.DeserializeObject<MessageSent>(data);
                if ((obj.Reciever == Sender || obj.Sender == Sender) && (obj.Sender == Reciever || obj.Reciever == Reciever))
                {
                    
                        txtHistory.Text += obj.Sender + " :" + obj.text + Environment.NewLine;
                        txtHistory.SelectionStart = txtHistory.Text.Length;
                        txtHistory.ScrollToCaret();
                    
                }
            });
        }
