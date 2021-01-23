    public interface IProcessorFactory
    {
      IProcessor Create(ProcessingType type);
    }
    
    internal class ProcessorFactory : IProcessorFactory
    {
      IProcessor Create(ProcessingType type)
      {
        IProcessor processor = null;
        // switch statement or perhaps indivual factory implementations for each processor type.
        // pick your poison
        switch(type)
        {
          case ProcessingType.Default:
            processor = new DefaultProcessor();
            break;
          ... etc.
        }
    
        return processor;
      }
    }
    
    public interface IProcessor
    {
        int GetID();
        float Value { get; set; }
        void SaveData();
    }
    
    internal class DefaultProcessor : IProcessor
    {
      float Value { get; set; }
    
      int GetID()
      {
        ...
      }
    
      void SaveData()
      {
        ...
      }
    }
