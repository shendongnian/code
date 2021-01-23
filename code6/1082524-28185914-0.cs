    public sealed class GlobalVars
    {
        static readonly GlobalVars instance = new GlobalVars();
        public Difficulty DifficultySet { get; set; }
        private GlobalVars()
        {
        }
        public static GlobalVars Instance
        {
            get
            {
                return instance;
            }
        }
        public enum Difficulty { Easy, Intermediate, Hard };
    }
    //main page
    GlobalVars pageInstance = GlobalVars.Instance;
    pageInstance.DifficultySet = GlobalVars.Difficulty.Easy;
    //other page
    if(GlobalVars.Instance.DifficultySet == GlobalVars.Difficulty.Easy)
    {
        //write your logic
    }
    
