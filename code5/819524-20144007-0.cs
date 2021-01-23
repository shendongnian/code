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
    // Factory looks at the type of memo and creates appropriate memo processor.
    MemoProcessorFactory.Create(memo).Run();
