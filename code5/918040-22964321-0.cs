    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Timers;
    using System.Threading.Tasks;
    namespace QuiddichGame
    {
        class Program
        {
            private static Game game
            private static Timer aTimer = new Timer(1000);
            static void Main(string[] args)
            {
                aTimer.Interval = 1000;
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Start();
    
                Championship champ = new Championship();
                game.GenerateTeams();// this should not be here
                Game game = new Game(champ.teams[0], champ.teams[1]);
                juego.CrearDisplay();
                game.CreateField();
    
                while (true) { int a = 1; }
            }
            //Actualization
            static private void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                //HOW DO I CALL THE "game" INSTANCE IN HERE??
            }
        }
    }
