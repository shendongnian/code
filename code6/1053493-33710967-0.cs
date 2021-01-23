        public async static Task SendMessage (string phoneNumber)
        {
            ChatMessage msg = new ChatMessage();
            msg.MessageKind = Windows.ApplicationModel.Chat.ChatMessageKind.Standard;
            msg.Body = "...";
            msg.Recipients.Add(phoneNumber);
            ChatMessageStore cms = await ChatMessageManager.RequestStoreAsync();
            cms.SendMessageAsync(msg);
        }
