            await _connection.Start();
            await _myHub.Invoke("Join");
            _myHub.On("recieved", data =>
            {
                var obj = JsonConvert.DeserializeObject<MessageSent>(data);
                messagewindows = new SendMessage(User, obj.Sender);
            
                     if ((obj.Reciever == User ) )
                     {
                        messagewindows. txtHistory.Text += obj.Sender + " :" + obj.text + Environment.NewLine;
                        messagewindows.Show();
                     }
               
               
            });
          
        }
