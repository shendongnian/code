        public enum Suit
        {
            Spades = 0x10,
            Hearts = 0x11,
            Clubs = 0x12,
            Diamonds = 0x13
        }
        private void print_suit()
        {
            foreach (var _suit in Enum.GetValues(typeof(Suit)))
            {
                int suitValue = (byte)(Suit)Enum.Parse(typeof(Suit), _suit.ToString());
                MessageBox.Show(_suit.ToString() + " value is 0x" + suitValue.ToString("X2"));
            }
        }
------------------------------------------------------
        Result of Message Boxes
        Spade value is 0x10
        Hearts value is 0x11
        Clubs value is 0x12
        Diamonds value is 0x13
