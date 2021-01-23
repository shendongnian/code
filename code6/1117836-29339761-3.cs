    void M()
    {
        // some other stuff
        cake.PropertyChanged += N;
        // some other stuff
    }
    void N(object mSender, EventArgs eventArgs)
    {
        listOfFinishedOrders.Items.Insert(count, cake.NameOfCake + eventArgs.PropertyName);
    }
