    class Sample
    {
       List<int> _usedIndexes;
    
       public Sample()
       {
          _usedIndexes = new List<int>();
       }   
    
       public int GetRandomIndex(int s, e)
       {
          Random rnd = new Random();
          
          //Initiate with something to compare against
          int x = -1; 
    
          x = rnd.Next(s, e);
    
          while(_usedIndexes.Exists(index => index == x))
          {
             x = rnd.Next(s, e);
          }
    
          _usedIndexes.Add(x);
    
          return x;
       }
    }
