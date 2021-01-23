    public class ParagonClass : INotifyPropertyChanged
    {
      //some variables
      private decimal _totalValue;
      public decimal TotalValue
      {
        get
        {
            if (ProductID > 0)
                _totalValue = Math.Round(ProductCount * PriceBrutto, 2, MidpointRounding.AwayFromZero);
            return _totalValue;
        }
      // No need for a setter if its calculated
      // See Sheridan's answer for how to do this
      //       set
      //       {
      //           _totalValue = value;
      //           NotifyPropertyChanged("TotalValue");
      //       }
      }
      ...
    }
