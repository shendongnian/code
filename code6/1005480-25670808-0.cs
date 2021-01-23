    MCApi mc = new MCApi(ConfigurationManager.AppSettings["MCAPIKey"], false);
    var subscribeOptions = new Opt<List.SubscribeOptions>(new List.SubscribeOptions { SendWelcome = true, UpdateExisting = true });
    var merges = new Opt<List.Merges>(new List.Merges { { "FNAME", [Subscriber FirstName here] }, { "LNAME", [Subscriber lastName here] } });
    if (mc.ListSubscribe(ConfigurationManager.AppSettings["MCListId"], [Subscriber email ], merges, subscribeOptions))
        // The user is subscribed Do Something
