    public void countEm(int numberOfThrows)
    {
          List<int> Throws = new List<int>(); //Create list, where value of throws will be stored.
          for(int i = 0; i < numberOfThrows) //Loop as many times as are given by parameter.
          {
              Throws.Add(OneThrow()); //Add return value of throw to the list.
          }
          //Show values in Throws list.
          foreach(var diceValue in Throws)
          {
               Console.WriteLine(string.Format("Value of throw: {0}", diceValue ));
          }
    } 
