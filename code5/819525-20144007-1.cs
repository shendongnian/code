    public interface IMemoProcessor
    { 
       void Run();
    }
    
    public class EmailMemoProcessor : IMemoProcessor
    {
       public void Run()
       {
          // Send email
       }
    }
    public class SmsMemoProcessor : IMemoProcessor
    {
       public void Run()
       {
          // Send sms
       }
    }
    // Factory looks at the type of memo and creates appropriate memo processor.
    var memoProcessor = MemoProcessorFactory.Create(memo);
    memoProcessor.Run();
