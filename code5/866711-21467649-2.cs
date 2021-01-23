     public class Score 
     {
         public int TheScore { get; private set; }
         public static _instance;
         public static Instance     // I'm using a static property, but you could also create a static "getInstance" method if you prefer
         {
             get 
             {
                 if (_instance == null) 
                 {
                     // Note: if you are multithreading, you might need some locking here to avoid ending up with more than one instance
                     _instance = new Score();
                 }
                 return _instance;
             }
         }
         private Score() 
         {
             // Note: it's important to have a private constructor so there is no way to make another instance of this object
         }
         public int AddToScore(int score)
         {
             // again - if you have multiple threads here you might need to be careful
             TheScore += score;
         }
     }
