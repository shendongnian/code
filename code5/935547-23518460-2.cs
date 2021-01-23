    public interface IAddModule
    {
        int Add(int lhs, int rhs);
    }
    public class Calculator
    {
        private readonly IAddModule _addModule;
        
        public Calculator(IAddModule addModule)
        {
            _addModule = addModule;
        }
        
        public int Add(int lhs, int rhs)
        {
            return _addModule.Add(lhs, rhs);
        }
    }
