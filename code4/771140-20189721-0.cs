    class Program
    {
        static void Main(string[] args)
        {
            // create an object of your adapter class and consume the features.
            AdapterInterfaceUI obj = new AdapterInterfaceUI();
            
            // Even though you have written an adapter it still performs the opertation in base class
            // which has the interface implementation and returns the value.
            // NOTE : you are consuming the interface but the object type is under your control as you are the owner of the adapter class that you have written.
            Console.WriteLine(obj.DisplayUI());
            Console.ReadKey();
        }
    }
    #region code that might be implemented in the component used.
    public interface IinterfaceUI
    {
        string DisplayUI();
    }
    public class ActualUI : IinterfaceUI
    {
        //Factory pattern that would be implemented in the component that you are consuming.
        public static IinterfaceUI GetInterfaceObject()
        { 
            return new ActualUI();
        }
        public string DisplayUI()
        {
            return "Interface implemented in ActualUI";
        }
    }
    #endregion
    #region The adapter class that you may need to implement in rsharper or c# which ever works for you.
    public class AdapterInterfaceUI : ActualUI, IinterfaceUI
    {
        public string DisplayUI()
        {
            return base.DisplayUI();
        }
    }
    #endregion
