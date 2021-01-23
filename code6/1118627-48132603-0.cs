    // create bot instance
    var bot = new TelegramBotClient("YourApiToken");
    
    // test your api configured correctly
    var me = await bot.GetMeAsync();
    Console.WriteLine($"{me.Username} started");
    
    // start listening for incoming messages
    while (true) 
    {
        //get incoming messages
        var updates = await bot.GetUpdatesAsync(offset);
        foreach (var update in updates)
        {
            // send response to incoming message
            await bot.SendTextMessageAsync(message.Chat.Id,"The Matrix has you...");
        }
    }
