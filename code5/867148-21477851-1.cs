    public partial class PriceControl<TDataSource, TPricesVat, TPriceNet, TPriceGross>
      : ANotifyPropertyXtraUserControl, IPriceControl<TDataSource, TPricesVat, TPriceNet, TPriceGross>
      where TDataSource : class, INotifyPropertyChanging, INotifyPropertyChanged
      where TPricesVat : struct
      where TPriceNet : struct
      where TPriceGross : struct
    {
    
       public void DoSomething(TPriceNet price) {}
       public void DoSomething(TPriceNet? price)
       {
           if(price.HasValue)
               DoSomething(price.Value);
           else
           {
              //throw exception? log? no-op?
           }
       }
    }
