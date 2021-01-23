    public class SyntaxError : Exception
    {
         public SyntaxError(int atLine)
         {
             AtLine = atLine;
         }
         public int AtLine { get; private set; }
    }
