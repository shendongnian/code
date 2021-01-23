    class Program
    {
        private static Timer aTimer = new Timer(1000);
        //Define your game in the class
        private static Game game;
        static void Main(string[] args)
        {
            aTimer.Interval = 1000;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();
            Championship champ = new Championship();
            game.GenerateTeams();
            game = new Game(champ.teams[0], champ.teams[1]);
            juego.CrearDisplay();
            game.CreateField();
            while (true) { int a = 1; }
        }
        //Actualization
        static private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            game.DoSomething();
        }
