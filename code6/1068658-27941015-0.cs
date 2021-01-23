            if (input.ShowDialog() == DialogResult.OK)
            {
                // string nickname = "shan";
                // string j = "";
                string Nickname = input.Result;
                input = new frmInputBox("Enter the Jid of the room to join (e.g jdev@conference.jabber.org)", "Room");
                
              if (input.ShowDialog() == DialogResult.OK)
                {
                    var roomJid = new Jid(input.Result);
                    new frmGroupChat(XmppCon, roomJid, Nickname).Show();
               
 }
            }
