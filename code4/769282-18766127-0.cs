    public ISourceBlock<Foo> CreateProducer()
    {
        var block = new BufferBlock<Foo>(); // add options if necessary
    
        Task.Run(() =>
        {
            try
            {
                while (whatever)
                {
                    Foo foo = …;
                    block.Post(foo); // or await SendAsync() if block is bounded
                }
            }
            catch (Exception ex)
            {
                ((IDataflowBlock)block).Fault(ex);
            }
        });
    
        return block;
    }
