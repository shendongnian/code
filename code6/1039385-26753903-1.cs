    public class classAA<T> 
        where T : ClassC
    {
        public List<T> MyList { get; set; }
    
        public void Foo()
        {
            foreach (var item in this.MyList)
            {
                item.MethodOfClassC();
            }
        }
    }
