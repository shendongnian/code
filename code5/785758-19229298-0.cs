    public class ProcWrapper
    {
      private TextProcessor _proc;
      private ActionBlock<string> _actBlock;
    
      public ProcWrapper(TextProcessor proc)
      {
        _proc = proc;
        
        _actBlock = new ActionBlock<string[]>(word=>
        {
          _proc.Run(word);
        });
      }
    
      public void AddWord(string words)
      {
        _actBlock.Post(word);
      }
      public void WaitForCompletion()
      {
        _actBlock.Completion.Wait();
      }
    }
