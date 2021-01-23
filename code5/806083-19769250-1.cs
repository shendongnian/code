    class Program
        {
            Player mob1 = new Player(); // mob1 and player are now of type Player
            Player player = new Player();
            static void Main(string[] args)
            {
                Next();
            }
            static public void Next()
            {
                mob1.Hp = 50;
                player.Hp = 100;
                Console.WriteLine("Player's HP: " + player.hp);
                Console.ReadKey();
            }
        }
    public class Player
    {
        public int Hp {get; set;}
    }
