    MockCommandBus : ICommandBus
    {
        ICommand PassedCommand { get; set; }
        MetaData PassedMetaData { get; set; }
    
        public void Send(ICommand command, MetaData metaData)
        {
            this.PassedCommand = command;
            this.PassedMetaData = metaData;
        }    
    }
