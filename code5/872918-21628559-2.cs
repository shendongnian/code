    var block = new ActionBlock<Item>(_ => _.Action.DynamicInvoke(_.Paramters));
    
    class Item
    {
        public Delegate Action { get; private set; }
        public object[] Parameters { get; private set; }
        public Item(Delegate action, object[] parameters)
        {
            Action = action;
            Parameters = parameters;
        }
    }
    
