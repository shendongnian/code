           var a = new CommunicatorAPI.Messenger();
            if(a.MyStatus == MISTATUS.MISTATUS_ONLINE)
            {
                MessageBox.Show("Online");
            }
            else if   (a.MyStatus == MISTATUS.MISTATUS_AWAY)
            {
                MessageBox.Show("Away");
            }
