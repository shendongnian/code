    var list = new List<MyItem>()
    {
        new MyItem(){ code = "1" , timestamp = new DateTime(2014,1,1)},
        new MyItem(){ code = "2" , timestamp = new DateTime(2014,1,2)},
        new MyItem(){ code = "1" , timestamp = new DateTime(2014,1,3)},
        new MyItem(){ code = "1" , timestamp = new DateTime(2014,1,4)},
        new MyItem(){ code = "2" , timestamp = new DateTime(2014,1,4)}  
    };
    DateTime latestAllowableTimestamp = new DateTime(2014, 1, 3);
