    public class Display
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Poker Game!");
            Console.WriteLine("\t" + "Enter to start game!");
            NewDeal oNewDeal = new NewDeal();
            Random newCard = new Random(System.DateTime.Now.Second);
            string _newCard = "";
            for (int card = 0; card <= 3; card++)
            {
                _newCard = oNewDeal.getCards(newCard.Next(0,oNewDeal.suit.Length - 1),newCard.Next(0,oNewDeal.rank.Length - 1));
                Console.Write("{0}\n", _newCard);
            }
                Console.Read();
        }
    }
    public class NewDeal
    {
        public string card = "";
        public string[] suit = new string[] { "♥","♠","♦","♣" };
        public const char DELIMETER = ',';
        public string[] rank = new string[] {"A","1","2","3","4","5","6","7","8","9","10","J","Q","K"};
        public string getCards(int _suit, int _rank)
        {
            return card = rank[_rank] + suit[_suit];
        }
    }
}
