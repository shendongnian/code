    public async Task PublishPriceChange()
    {
        await Task.Run(() =>
        {
            lock (_locker)
            {
                for (int i = 0; i < 200; i++)
                {                  
                    TransformPrices(_quotes);
                    PriceChangeEventArgs e = new PriceChangeEventArgs(_quotes);
                    PriceChanged(this, e);
                }
            }  
        });           
    }
