    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          Input userInput = Input.Rock;
          Result result = Play(userInput);
          Console.WriteLine(Enum.GetName(result.GetType(), result));
          Console.ReadKey();
        }
    
        static Result Play(Input userInput)
        {
          Input computer = Input.Scissors;
    
          switch (userInput)
          {
            case Input.Paper:
              switch (computer)
              {
                case Input.Paper: return Result.Draw;
                case Input.Rock: return Result.Win;
                case Input.Scissors: return Result.Lose;
                default: throw new Exception("Logic fail.");
              }
            case Input.Rock:
              switch (computer)
              {
                case Input.Paper: return Result.Lose;
                case Input.Rock: return Result.Draw;
                case Input.Scissors: return Result.Win;
                default: throw new Exception("Logic fail.");
              }
            case Input.Scissors:
              switch (computer)
              {
                case Input.Paper: return Result.Win;
                case Input.Rock: return Result.Lose;
                case Input.Scissors: return Result.Draw;
                default: throw new Exception("Logic fail.");
              }
            default: throw new Exception("Logic fail.");
          }
        }
      }
      enum Input
      {
        Rock,
        Paper,
        Scissors
      }
      enum Result
      {
        Lose,
        Draw,
        Win
      }
    }
