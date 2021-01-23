    void Main()
    {
    	var publisher = new Publisher();
    	var subscriberOne = new SubscriberOne();
    	var subscriberTwo = new SubscriberTwo();
    	
    	publisher.MyDeleteEvent += subscriberOne.OnSomethingOccured;
    	publisher.MyDeleteEvent += subscriberTwo.OnSomethingOccured;
    }
