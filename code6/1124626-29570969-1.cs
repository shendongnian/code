    class CFiles
    {
        //private int[] v=new int[5];//dont want to specify the dimention of array here
        private int[] v;
        public int[] V { get { return v; } set { v = value; } }
    
        private List<string> words;
        public List<string> Words { get { return words; } set { words = value; } }
    
        public CFiles()
        {
            words = new List<string>();
            v = new int[51]; //needs to be 51 if you are going to assign to index 50 below
        }
    }
