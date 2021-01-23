    public class ExistingClass 
    {
        
    }
    public static class ExtendingExistingClass 
    {
        private static Dictionary<ExistingClass,List> _values = new Dictionary<ExistingClass,List>();
        public List GetMyNewField(this ExistingClass t)
        {
           List res = null;
           _values.TryGetValue(t, out res);
           return res; 
        }
        
        public void SetMyNewField(this ExistingClass t, List value)
        {
           _values[t] = value;
        }
    }
