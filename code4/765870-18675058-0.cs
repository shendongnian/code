    public class Result
    {
    
       public Dice D1 { get; set; }
       public Dice D2 { get; set; }
       public Dice D3 { get; set; }
    
       // Always has three dices ...
       public Result(Dice d1,Dice d2,Dice d3)
       {
          D1 = d1;
          D2 = d2;
          D3 = d3; 
       }
       
       public bool Match(IEnumerable<Dice> dice)
       {
    		return ...; // Your comparison logic here
       }
    }
    
    var bets = new List<Bet>();
    
    foreach(var bet in bets)
    {
    	var matchCount = bet.Count(x => Result.Match(x.Dices));
    }
