    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine ("Hello GameWorld!");
            GameWorld gameWorld = new GameWorld(new Progress<long> (s => Console.WriteLine("{0}ms elapsed.", s)));
            gameWorld.Update();
            while (gameWorld.GameState == GameState.Runs) {
                gameWorld.PlayerMovement();
                gameWorld.Update();
            }
        }
    }
    public enum GameState { Runs, Stopped }
    public class GameWorld
    {
        public GameWorld(IProgress<long> progress)
        {
            this.GameState = GameState.Runs;
            Task.Factory.StartNew (() =>
            {
                var stopWatch = Stopwatch.StartNew();
                for (var n = 0; n < 60;)
                {
                    var delay = ++n * 1000 - (int)stopWatch.ElapsedMilliseconds;
                    Task.Delay(delay).Wait();
                    progress.Report(stopWatch.ElapsedMilliseconds);
                }
                this.GameState = GameState.Stopped;
            });
        }
        public GameState GameState { get; private set; }
        public void PlayerMovement(){
        }
        public void Update(){
        }
    }
