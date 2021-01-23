    using System;
    
    public class Rps {
      public enum PlayerChoice { Rock, Paper, Scissors };
      public enum Result { Draw, FirstWin, FirstLose};
    
      public static Result Match(PlayerChoice player1, PlayerChoice player2) {
        return (Result)(((int)player1 - (int)player2 + 3) % 3);
      }
      public static void Main() {
        Rps.Test(Match(PlayerChoice.Rock, PlayerChoice.Rock), Result.Draw);
        Rps.Test(Match(PlayerChoice.Paper, PlayerChoice.Paper), Result.Draw);
        Rps.Test(Match(PlayerChoice.Scissors, PlayerChoice.Scissors), Result.Draw);
        Rps.Test(Match(PlayerChoice.Rock, PlayerChoice.Scissors), Result.FirstWin);
        Rps.Test(Match(PlayerChoice.Rock, PlayerChoice.Paper), Result.FirstLose);
        Rps.Test(Match(PlayerChoice.Paper, PlayerChoice.Rock), Result.FirstWin);
        Rps.Test(Match(PlayerChoice.Paper, PlayerChoice.Scissors), Result.FirstLose);
        Rps.Test(Match(PlayerChoice.Scissors, PlayerChoice.Paper), Result.FirstWin);
        Rps.Test(Match(PlayerChoice.Scissors, PlayerChoice.Rock), Result.FirstLose);
      }
      
      public static void Test(Result sample, Result origin) {
        Console.WriteLine(sample == origin);
      }      
    }
