    public class Bowling
    {
         public void Throw(int count) // How do you call these things that you need to knock over...
         {
             Debug.Assert(count >= 0);
             Debug.Assert(count <= 12);
             // ... Lots of interesting code.
         }
    
         public int GetScore()
         {
              return 16;
         }
    }
