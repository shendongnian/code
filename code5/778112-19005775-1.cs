    public class ViewModel : INotifyPropertyChanged
    {
        private FunctionalTester _funcTester;
        public FunctionalTester FuncTester
        {
            get
            {
                return _funcTester;
            }
            set
            {
                _funcTester = value;
                OnPropertyChanged( "FuncTester" );
            }
        }
        public async void TestAsync( )
        {
            await _funcTester.Test( );
        }
    }
