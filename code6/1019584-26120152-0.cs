    public class A
    {
        public int id { set; get; }
        public int a1 { set; get; }
        public A2 a2 { set; get; }
        public int a3 { set; get; }
    }
    public class A2
    {
        public string text { set; get; }
    }
    public interface IARepository
    {
        A Select(int id);
        IList<A> SelectAll();
        void Delete(int id);
        void Update(A selection);
        void Insert(A selection);
    
        IList<A> SelectAllByA2(A2 a2);  // or IList<A> SelectAllByA2(string a2Text);  
    }
    public interface IA2Repository
    {
        IList<A2> SelectDistinctA2();          
    }
