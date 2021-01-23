    public class Display
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Poker Game!");
            Console.WriteLine("\t" + "Enter 'deal' to start game!");
            NewDeal oNewDeal = new NewDeal();
            Console.WriteLine("Hand is: {0}", oNewDeal.dealer());   //<-- Not sure how to invoke the 'hand'    // i don't get what you want to do here
            Console.Read();
        }
    }
    public class NewDeal
    {
        public string _card;
        public string suit = "♥,♠,♦,♣";
        public const char DELIMETER = ',';
        public string rank = "A,1,2,3,4,5,6,7,8,9,10,J,Q,K";
        public string dealer()
        {
            string _card = "";
            string[] singleSuit = suit.Split(DELIMETER);
            string[] singleRank = rank.Split(DELIMETER);
            foreach(string s in singleSuit)
            {
                _card = s + singleRank;       
            }
            return _card;
        }
    }
}
