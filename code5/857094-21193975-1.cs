    public class ActionPerformer : ISomething
    {
        public void PerformAction()
        {
            ...
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            ActionManager manager = new ActionManager();
            ActionPerformer performer = new ActionPerformer();
    
            manager.DoSomething(performer);
        }
    }
