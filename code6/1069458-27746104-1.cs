    class Card
    {
        ...
        public static implicit operator Card( string s )
        {
            return new Card( s );
        }
        ...
    }
    var ca = new Card[] { "4S", "5C", "AH" };
