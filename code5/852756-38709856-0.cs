    public class RandomDice
    {
       private const int NUMBER_OF_DICE = 5;
       private const int MAX_DICE_VALUE = 6;
       private static readonly Random Rng = new Random();
       public List<int> NumberList = new List<int>();
     
       private static IEnumerable<int> GetRandomNumbers()
       {
          while (true)
          yield return Rng.Next(1, MAX_DICE_VALUE + 1);
       }
       internal void AddDice()
       {
          NumberList.Clear();
          NumberList.AddRange(GetRandomNumbers().Take(NUMBER_OF_DICE).ToList());
       }
    }
