    var block = new ActionBlock<Item>(_ => _.Action.DynamicInvoke(_.Paramters));
    
    class Item
    {
        public Delegate Action;
        public Objects[] Parameters;
    }
    
