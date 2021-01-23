    public int Second
    {
         get
         {
            return (int)((InternalTicks / TicksPerSecond) % 60); 
         }
    } 
