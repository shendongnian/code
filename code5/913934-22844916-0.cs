    public class MyClass<T> 
    {
        private List<T> MyList;
        public MyClass(List<T> list) 
        {
            this.MyList = list;
        }
        public T this[int i]
        {
            get
            {
                return MyList[i];
            }
            set
            {
                MyList[i] = value;
            }
        }
    }
