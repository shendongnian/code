    private Task<IList<MyClass>> GetStuffViaLongRunningTask()
    {
        return Task.Factory.StartNew(() =>
        {
            //...Calls to get and build up IList<MyClass>
            // You can make synchronous calls here
            return list;
        });
    }
