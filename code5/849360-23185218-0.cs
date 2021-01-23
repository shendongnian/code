    private async void bwSubscription_DoWork(object sender, DoWorkEventArgs e)
    {
        bool subscriped = false;
        List<object> genericlist = e.Argument as List<object>;
        var table = App.MobileService.GetTable<ChatRoomOverview.chatrooms>();
        //List<ChatRoomOverview.chatrooms> ChatRooms = table.Where(chat => chat.chatroomName == ChatroomName.Text)
        //table.InsertAsync(ChatRoom);
        ChatRoomOverview.chatrooms chat = (ChatRoomOverview.chatrooms)genericlist[0];
        //var ChatRoom = table.Where(chatting => chatting.chatroomName == chat.chatroomName).ToListAsync();
        long tempID = chat.Id;
        while (!subscriped)
        {
            try
            {
                ChatRoomOverview.Subscription Subscription = new ChatRoomOverview.Subscription { ContentID = tempID, userId = App.UserInfromationID , Notifications = 0};
                await App.MobileService.GetTable<ChatRoomOverview.Subscription>().InsertAsync(Subscription);
            }
            catch
            {
            }
            List<ChatRoomOverview.Subscription> subscript = await App.MobileService.GetTable<ChatRoomOverview.Subscription>().Where(subs => subs.ContentID == tempID && subs.userId == App.UserInfromationID && subs.Notifications == 0).ToListAsync();
            if (subscript.Count > 0)
            {
                ChatRoomOverview.userName = "";
                subscriped = true;
            }
            else
            {
                subscriped = false;
            }
        }
    }
