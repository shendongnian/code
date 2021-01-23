    public void countEm(int numberOfThrows)
    {
          List<int> Throws = new List<int>();
          for(int i = 0; i < numberOfThrows)
          {
              Throws.Add(OneThrow());
          }
          //Show values in Throws list.
          foreach(var diceValue in Throws)
          {
               Console.WriteLine(string.Format("Value of throw: {0}", diceValue ));
          }
    } 
