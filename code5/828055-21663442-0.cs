    [ComVisible(true)]
    [Guid("516FED99-YOUR-GUID-HERE-C9EA0177568A")]
    public interface  IMathOperation
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }
    [ComVisible(true)]
    [Guid("4354D883-YOUR-GUID-HERE-155A0DE30318")]
    [ClassInterface(ClassInterfaceType.None)]
    public class MathOperation:IMathOperation
    {
    
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
