    internal class Card
    {
        public int Value { get; set; }
        public Image Picture { get; private set; }
        public Suit Suit { get; set; }
        public Card(int value, Suit suit)
        {
            this.Value = value;
            this.Suit = suit;
            // Load the correct picture automatically based on value and suit
            string firstLetterOfSuit = suit.ToString().First().ToString();
            string picturePath = string.Format("Pictures/{0}{1}.png", 
                firstLetterOfSuit, value);
            this.Picture = Image.FromFile(picturePath);
        }
    }
