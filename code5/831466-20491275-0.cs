    [ComVisible(true)] 
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)] 
    public interface IComScriptEngineEvents
    {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="message"></param>
      [DispId((int)IComScriptEngineEventsDispatchIDs.CompileError)]
      void CompileError(string message);
    }
    
    
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ScriptEngineComWrapper.ComScriptEngine")]
    [ComVisible(true)]
    [ComSourceInterfaces(typeof(IComScriptEngineEvents))]
    public class ComScriptEngine : IComScriptEngine
    {
    	[ComVisible(false)]
    	public delegate void CompileErrorDelegate(string message); 
        public event CompileErrorDelegate CompileError;
    }
    
