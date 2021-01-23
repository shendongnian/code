    public class ViewModel : ObservableObject
    {
        private int _x;
        public int X
        {
            get { return _x; }
            set { SetField(ref _x, value); }
        }
    
        private int _y;
    
        public int Y
        {
            get { return _y; }
            set { SetField(ref _y, value); }
    
        }
    
        //use the CalculatedProperty annotation for properties that depend on other properties and pass it the prop names that it depends on
        [CalculatedProperty("X", "Y")]
        public int Z
        {
            get { return X * Y; }
        }
    
        [CalculatedProperty("Z")]
        public int M
        {
            get { return Y * Z; }
        }
    
    }
