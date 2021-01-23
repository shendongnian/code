        public class MyFile
    {
        public struct FileHeader
        {
            internal MyFile _parent;
            public List<string> ColNames
            {
                get;
                set;
            }
            public void setColNames()
            {
                ColNames = new List<string>();
                ColNames.Add("address");
                _parent._h = this;
            }
        }
        private FileHeader _h = new FileHeader();
        public FileHeader h
        {
            get { return _h; }
        }  
      
        public MyFile()
        {
            _h._parent = this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyFile o = new MyFile();
            o.h.setColNames();
            Console.WriteLine(o.h.ColNames[0]);
            string line = System.Console.ReadLine();
        }
    }
