    using(var service = new MyService()) //MyService is the name of your service reference
    {
        var searchConsumers = service.GetConsumer(transformer, account);
        //Then loop your list
        foreach(var searchConsumer in searchConsumers)
        {
            //Now access properties
            //searchConsumer.Firstname, searchConsumer.Lastname
        }
    }
