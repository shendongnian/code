    public class Parent
    {
        public Parent()
        {
            GetData();
        }
        private void GetData()
        {
        }        
        public class Child1 : Parent
        {
            public Child1()
            {
                GetData();
            }
        }
    }
    class Child2 : Parent.Child1
    {
        public Child2()
        {
            GetData(); //compiler error, inaccessible due to protection level
        }
    }
