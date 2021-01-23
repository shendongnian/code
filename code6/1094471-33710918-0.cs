        public async static Task SendMessage (string phoneNumber)
        {
            ChatMessage msg = new ChatMessage();
            msg.MessageKind = Windows.ApplicationModel.Chat.ChatMessageKind.Standard;
            msg.Recipients.Add(phoneNumber);
            await ChatMessageManager.ShowComposeSmsMessageAsync(msg);
        }
