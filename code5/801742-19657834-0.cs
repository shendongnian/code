    public abstract class Game
    {
        public abstract void BeatScissorsAndLizard<T>(T weapon)
            where T : IBeatScissors, IBeatLizard;
        public abstract void BeatPaperAndLizard<T>(T weapon)
            where T : IBeatPaper, IBeatLizard;
        
        //more here...
    }
