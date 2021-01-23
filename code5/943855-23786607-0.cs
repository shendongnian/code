    public interface IValue
    {
        public void OperationOnValue();
    }
    
    public class CompositePList : IValue
    {
        private Dictionary<string, IValue> dict;
        public void OperationOnValue()
        {
            foreach(var things in dict)
            {}//things to do
        }
    }
    
    public class StringValue : IValue
    {
        private string leafValue;
        public void OperationOnValue()
        {}//thing to do
    }
