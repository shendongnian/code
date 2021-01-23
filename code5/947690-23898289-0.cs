    public decimal MeanForParticularDate( DateTime desired , Dictionary<DateTime,int>[] collection )
    {
      decimal mean = collection
                     .SelectMany(
                       entry => entry
                                .Where(  x => x.Key == desired  )
                                .Select( x => (decimal) x.Value )
                       )
                     .Average()
                     ;
      return mean ;
    }
