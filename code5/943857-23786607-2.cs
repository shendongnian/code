    public interface IValue
    {
        public void OperationOnValue();
        public List<IValue> GetChildren();
    }
    
    public class CompositePList : IValue
    {
        private Dictionary<string, IValue> dict;
        public void OperationOnValue()
        {
            foreach(var things in dict)
            {}//things to do
        }
        public List<IValue> GetChildren()
        {
            return dict.Select(keyValue => keyValue.Value).ToList();
        }
    }
    
    public class StringValue : IValue
    {
        private string leafValue;
        public void OperationOnValue()
        {}//thing to do
        public List<Children> GetChildren()
        {
            return null; //or return new List<Children>()
        }
    }
