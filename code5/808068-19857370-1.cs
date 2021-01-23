    public class CorrelationTableRowViewModel : ViewModelBase
        {
            private string _ccy;
            private readonly IList<FxCorrelation> _correlations;
    
            public CorrelationTableRowViewModel(string ccy)
            {
                _ccy = ccy;
                _correlations = new List<FxCorrelation>();
            }
    
            public string Ccy
            {
                get { return _ccy; }
                set
                {
                    _ccy = value;
                    RaisePropertyChanged("Ccy");
                }
            }
    
            public IList<FxCorrelation>  Correlations
            {
                get { return _correlations; }
            }
        }
