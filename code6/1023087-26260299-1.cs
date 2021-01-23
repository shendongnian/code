    public class Game
    {
        public int Id {get;set;}
        
        [InverseProperty("Game")]
        List<Action> ActiveActionList {get;set;}
        [InverseProperty("PassiveGame")]
        List<Action> PassiveActionList {get;set;}
        ... (several other variables)
    }
    public class Action
    {
        public int Id {get;set;}
        Game Game {get;set;}
        Game PassiveGame {get;set;}
        ...(several other variables)
    }
