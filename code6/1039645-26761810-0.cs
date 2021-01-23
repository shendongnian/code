    // I make it sealed so you can use the "easier" dispose pattern, if it is not sealed
    // you should create a `protected virtual void Dispose(bool disposing)` method.
    public sealed class logger : IDisposeable
    {
        private StreamWriter sw;
        public logger(string fileName)
        {
            sw = new StreamWriter(fileName, true);
        }
    
        public void LogString(string txt)
        {
            sw.WriteLine(txt);
            sw.Flush();
        }
    
        public void Close()
        {
            sw.Close();
        }
    
        public void Dispose()
        {
            if(sw != null)
                sw.Dispose();
        }
    }
