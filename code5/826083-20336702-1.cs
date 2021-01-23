    public static class MyExtensions
    {
        public static public bool IsMaxed( this int value )
        {
            return value > 50; // or whatever
        }
    }
    int thing = 10;
    bool result = thing.IsMaxed( );
