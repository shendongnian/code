    public class UserControl
    {
        public Func<object, object> oDel = null;
        public void Execute()
        {
            oDel?.Invoke("HELLO WORLD!");
        }
    }
