    public static class ExtensionMethods
    {
        public static int? AsInteger( this string str)
        {
            int value;
            if ( int.TryParse( str, out value ) )
            {
                return value;
            }
            else
            {
                return null;
            }
        }
    }
