    public MyServiceConsumer(IItem item, IContainer container)
    {
        this.item = item;
        this.processor = item.GetStrategy(container);
    }
