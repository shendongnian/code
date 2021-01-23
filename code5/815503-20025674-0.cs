    public class GB
    {
        private string str;
        public GB()
        {
            using (var sr = new StreamReader(new FileStream("C:\\temp.txt", FileMode.Open, FileAccess.ReadWrite)))
            {
              str = sr.ReadToEnd();
            }
        }
        public int MultiCall()
        {
            if (str == "test1")
                return 1;
            else
                return 0;
        }
    }
