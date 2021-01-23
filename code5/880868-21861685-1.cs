    public class MyClass : IDisposable
    {
        StreamReader reader;
        
        public MyClass(string path)
        {
            this.reader = new StreamReader(path);
        }
        
        public string NextLine()
        {
            return this.reader.ReadLine();
        }
        
        public void Dispose()
        {
            reader.Dispose();
        }
    }
    
