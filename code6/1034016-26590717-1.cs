    public class SMTPServer : IDisposable
    {
        // all the other stuff
    
        public void Dispose()
        {
            writer.Dispose();
            reader.Dispose();
            stream.Dispose();
        }
    }
