    public class FileLoger : ILogger
        {
            public static IHostingEnvironment _env;
            private static object locker = new object();
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                var message = string.Format("{0}: {1} - {2}", logLevel.ToString(), eventId.Id, formatter(state, exception));
                WriteMessageToFile(message);
            }
            private static void WriteMessageToFile(string message)
            {
                string dateStr = DateTime.Now.Date.Day.ToString()+"_"+ DateTime.Now.Date.Month.ToString()+"_"+ DateTime.Now.Date.Year.ToString();
                if (!Directory.Exists("Logs"))
                {
                    DirectoryInfo di = Directory.CreateDirectory("Logs");
                }
    
                //Guid guidGenerator = Guid.NewGuid();
                string filePath = _env.ContentRootPath + "\\Logs\\ProcessLog_" + dateStr + ".txt";
                FileInfo fi = new FileInfo(filePath);
    
                lock (locker)
                {
                    using (FileStream file = new FileStream(fi.FullName, FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (StreamWriter streamWriter = new StreamWriter(file))
                    {
                        streamWriter.WriteLine(message);
                        streamWriter.Close();
                    }
                }
    
            }
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }
        }
    
        public class FileLogProvider : ILoggerProvider
        {
    
            public FileLogProvider(IHostingEnvironment env)
            {
                FileLoger._env = env;
            }
    
            public ILogger CreateLogger(string category)
            {
                return new FileLoger();
            }
            public void Dispose()
            {
    
            }
        }
