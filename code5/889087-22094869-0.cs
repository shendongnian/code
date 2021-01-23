    interface IMyInterface{
        int GetState();
    }
    public class GenericList<T> : List<T> where T: IMyInterface 
    {          
        public DateTime date { get; set; }
        public int GetState(int i){return this[i].GetState(); }
    }
