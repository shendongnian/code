    interface IControl
    {
        void Paint();
    }
    
    public class SampleClass : IControl
    {
        void IControl.Paint()
        {
            System.Console.WriteLine("IControl.Paint");
        }
        protected void Paint()
        {
            // you can declare that one, because IControl.Paint is already fulfilled.
        }
    }
