    public class UniqueColorGenerator {
            private int _colorIndex;
            private readonly int _offsetIncrement;
    
            public UniqueColorGenerator() {
                this._offsetIncrement = 1;
            }
    
            public UniqueColorGenerator( uint offsetIncrement ) {
                this._offsetIncrement = ( int )offsetIncrement;
            }
    
            public Color Next() {
                return Color.FromArgb( _colorIndex += _offsetIncrement );
            }
        }
