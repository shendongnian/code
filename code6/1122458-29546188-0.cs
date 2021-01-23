    public class ApplyCancelList<T>
    {
        List<T> snapshot = null;
    
        public List<T> List { get; private set; }
    
        public ApplyCancelList()
        {
            List = new List<T>();
        }
    
        public void CreateMemento()
        {
            snapshot = new List<T>(List);
        }
   
        public void RejectChanges()
        {
            List = new List<T>(snapshot);
        }
    }
