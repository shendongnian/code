    public class DoubleScoreResult
    {
      double value {get; private set}
      bool success {get; private set}
      Exception ex {get; private set};
    }
    
    function DoubleScoreResult DoubleScore()
    {
      var result = new DoubleScoreResult();
    
       ...
    
      return result;
    }
