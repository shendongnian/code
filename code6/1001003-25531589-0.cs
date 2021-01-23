    public class TESTClass<I, M>
           where I : IInterval<int, M>, new()
           where M : IData, new()
    { 
       public I interval{ set; get; }
    
       public TESTClass()
       {
           interval = new I() { left = 0, data = new M {value = 0} };
       }
    }
