    class Captured1
    {
        private readonly int count;
        private readonly Cake cake;
        private readonly ListBox listOfFinishedOrders;
        public Captured1(int count, Cake cake, ListBox listOfFinishedOrders)
        {
            this.count = count;
            this.cake = cake;
            this.listOfFinishedOrders = listOfFinishedOrders;
        }
        public void N(object mSender, EventArgs eventArgs)
        {
            listOfFinishedOrders.Items.Insert(count,
                cake.NameOfCake + eventArgs.PropertyName);
        }
    }
    void M()
    {
        // some other stuff
        Captured1 c = new Captured1(count, cake, listOfFinishedOrders);
        cake.PropertyChanged += c.N;
        // some other stuff
    }
