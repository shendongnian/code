    public partial class Weight: INotifyPropertyChanged
    {
      //.....
      decimal  _benchmarkweight;
      decimal  _securityweight;
      public decimal Benchmark_Weight 
      {
         get{return _benchmarkweight;}
         set{
             _benchmarkweight=value; 
             OnPropertyChanged("Benchmark_Weight ");  
             OnPropertyChanged("DiffValues");
            }
      }
      public decimal Security_Weight
      {
         get{return _securityweight;}
         set{
             _securityweight=value; 
             OnPropertyChanged("Security_Weight");  
             OnPropertyChanged("DiffValues");
            }
      }
      //.....
    }
