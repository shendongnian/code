    public interface IMemorable {}
    
    public struct Memorable<T> : IMemorable where T : struct 
    {
        private T Data;
    
        public Memorable(T data) 
        {
            Data = data;
        }
    }
    List<IMemorable> memorables = new List<IMemorable>();
    memorables.Add(new Memorable<someStruct>(new someStruct()));
    memorables.Add(new Memorable<otherStruct>(new otherStruct(6, "Six")));
