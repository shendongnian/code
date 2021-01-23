    public void PublishPriceChange()
    {
        Task.Run(() =>
        {
             for (int i = 0; i < 200; i++)
             {
                  
                       int j = i;
                       lock (_locker)
                       {
                          TransformPrices(_quotes);
                          PriceChangeEventArgs e = new PriceChangeEventArgs(_quotes);
                          PriceChanged(this, e);
                       }
                                  
             }  
        });           
    }
