    public interface IMarshal
    {
        void ReleaseComObject(object obj);
    }
    
    public class MarshalWrapper : IMarshal
    {
        public void ReleaseComObject(object obj)
        {
            if (Marshal.IsComObject(obj))
            {
                Marshal.ReleaseComObject(obj);
            }
        }
    }
