    class Card
    {
        ...
        public static explicit operator Card( string s )
        {
            return new Card( s );
        }
        ...
    }
    var ca = new Card[] { (Card)"4S", (Card)"5C", (Card)"AH" };
