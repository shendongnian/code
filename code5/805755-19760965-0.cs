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
    }
