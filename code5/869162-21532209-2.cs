    public class Test
    {
        private int _val1;
    
        public int GetVal(int fld)
        {
            Console.WriteLine("GetVal:" + fld);
            if (fld == 1) return _val1;
            return 0;
        }
    
        public void SetVal(int fld, int val)
        {
            Console.WriteLine("SetVal:" + fld);
            if (fld == 1) _val1 = val;
        }
    }
