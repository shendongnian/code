    interface IExpose<IToolType> where IToolType : ITool
    {
      IToolType Handler { get; set; }
    }
    
    class Expose : IExpose<Tool>
    {
      public Tool Handler { get; set; }
    }
    
    interface ITool
    {
    }
    
    class Tool : ITool
    {
    }
