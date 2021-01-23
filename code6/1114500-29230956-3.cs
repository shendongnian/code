    public class <NotWorking>d__1
    {
        private int <>1__state;
        // .. more things
        private List<int>.Enumerator enumerator;
    
        public void MoveNext()
        {
            switch (<>1__state)
            {
                case 0:
                    var list = new List<int> {1, 2, 3};
                    enumerator = list.GetEnumerator();
                    <>1__state = 1;
                    break;
    
                case 1:
                    var dummy1 = enumerator;
                    Trace.WriteLine(dummy1.MoveNext());
                    var dummy2 = enumerator;
                    Trace.WriteLine(dummy2.Current);
                    <>1__state = 2;
                    break;
