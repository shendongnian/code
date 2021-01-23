    /////code to be part of a room
    var input = new frmInputBox("Enter your Nickname for the chatroom", "Nickname", "Nickname");
           
            if (input.ShowDialog() == DialogResult.OK)
            {
                // string nickname = "shan";
                // string j = "";
                string Nickname = input.Result;
                input = new frmInputBox("Enter the Jid of the room to join (e.g jdev@conference.jabber.org)", "Room");
                
              if (input.ShowDialog() == DialogResult.OK)
                {
                    Jid jid = new Jid((string)node.Tag);
                    string nickname = input.Result;
                    frmGroupChat gc = new frmGroupChat(this.XmppCon, jid, nickname);
                    gc.Show(); }}
