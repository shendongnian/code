    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Menu menu = new Menu(game);
            game.Finished += menu.AskAndRun;
            menu.Welcome();
        }
    }
    class Menu
    {
        public readonly IRunnable runnable;
        public Menu(IRunnable runnable)
        {
            this.runnable = runnable;
        }
        public void Welcome()
        {
            Console.WriteLine("Welcome, Player!");
            AskAndRun();
        }
        public void AskAndRun()
        {
            Console.WriteLine("\nTo play a new game, press [ENTER]");
            Console.ReadLine();
            runnable.Run();
        }
    }
    interface IRunnable
    {
        void Run();
    }
    class Game : IRunnable
    {
        public event Action Finished;
        public void Run()
        {
            Console.WriteLine("Game started here...");
            Console.WriteLine("Oops! Game finished already");
            if (Finished != null)
            {
                Finished();
            }
        }
    }
