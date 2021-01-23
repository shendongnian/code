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
          
          //Initialize with a random number
          int x = rnd.Next(s, e);
          //While the index exists in the list of used indexes, get another random number.
          while(_usedIndexes.Exists(index => index == x))
          {
             x = rnd.Next(s, e);
          }
    
          //Add the number to the list of used indexes 
          _usedIndexes.Add(x);
    
          return x;
       }
    }
