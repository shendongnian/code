    public class WeightViewModel : INotifyPropertyChanged
    {
        public decimal Benchmark_Weight 
        { 
            get{ return _weight.Benchmark_Weight; } 
            set
            { 
                _weight.Benchmark_Weight = value;
                OnPropertyChanged("Benchmark_Weight");
                OnPropertyChanged("ActiveWeight");
            }
        }
        public decimal Security_Weight 
        { 
            get{ return _weight.Security_Weight; } 
            set
            { 
                _weight.Security_Weight = value;
                OnPropertyChanged("Security_Weight");
                OnPropertyChanged("ActiveWeight");
            }
        }
        public decimal ActiveWeight
        {
            get { return Security_Weight - Benchmark_Weight; }
        }
        
        private Weight _weight;
        public WeightViewModel(Weight weight){ _weight = weight; }
    }
