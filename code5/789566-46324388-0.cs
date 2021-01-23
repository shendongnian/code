    public class ErrorListener : BaseErrorListener
    {
        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Console.WriteLine("{0}: line {1}/column {2} {3}", e, line, charPositionInLine, msg);
        }
    }
