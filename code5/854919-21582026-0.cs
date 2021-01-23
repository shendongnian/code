      class TextLogTraceListener : TextWriterTraceListener
        {
            private string logFileLocation = string.Empty;
    
            private StreamWriter traceWriter;
    
            public TextLogTraceListener(string filePath)
            {
                logFileLocation = filePath;
                traceWriter = new StreamWriter(filePath, true);
                traceWriter.AutoFlush = true;
            }
    
            public override void Write(string message)
            {
                traceWriter.Write(message);
            }
    
            public override void WriteLine(string message)
            {
                traceWriter.WriteLine(message);
            }
    
            public override void Close()
            {
                traceWriter.Close();
            }
        }
