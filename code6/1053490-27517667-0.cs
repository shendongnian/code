    Windows.ApplicationModel.Chat.ChatMessage msg = new Windows.ApplicationModel.Chat.ChatMessage();
    msg.Body = "This is body of demo message.";
    msg.Recipients.Add("10086");
    msg.Recipients.Add("10010");
    await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(msg);
