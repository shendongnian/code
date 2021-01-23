    using(var service = new MyService()) //MyService is the name of your service reference
    {
        var searchConsumer = service.GetConsumer(transformer, account);
        //Now access properties
        //searchConsumer.Firstname, searchConsumer.Lastname
    }
