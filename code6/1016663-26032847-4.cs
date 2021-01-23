    using(var service = new MyService()) //MyService is the name of your service reference
    {
        service.GetConsumerCompleted += GetConsumerCompletedCallback;
        service.GetConsumerAsync(transformer, account);
    }
    //this method can be auto generated when hitting tab twice in visual studio after adding +=
    public void (object sender, GetConsumerCompletedEventArgs e)
    {
        //e.Result.Firstname, e.Result.Lastname
        //or if you are returning a list then loop over using code above
    }
