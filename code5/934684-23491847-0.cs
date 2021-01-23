    public class MyVisitor : ISomethingVisitor
    {
        private int p1;
        private int p2;
        public MyVisitor(int p1, int p2)
        {
           _p1 = p1;
           _p2 = p2;
        }
        public void Visit(Foo foo)
        {
            //got access to _p1, _p2 here 
        }
    }
