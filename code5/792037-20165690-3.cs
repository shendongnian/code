    namespace MyAssembly.log4net.Header.Example
    {
        public class HeaderAppender : RollingFileAppender
        {
            protected override void WriteHeader()
            {
                if (LockingModel.AcquireLock().Length == 0)
                {
                    base.WriteHeader();
                }
            }
        }
    
        public class HeaderPatternLayout : PatternLayout
        {
            public override string Header
            {
                get
                {
                    StringBuilder headerBuilder = new StringBuilder();
                    headerBuilder.AppendLine("Static information");
                    headerBuilder.AppendLine("OS Version: "
                              + Environment.OSVersion);
                    headerBuilder.AppendLine("Culture Info: "
                              + CultureInfo.CurrentCulture);
                    headerBuilder.AppendLine("[Etc] ");
                    headerBuilder.AppendLine();
                    headerBuilder.AppendLine("Messages:");    
  
                    return headerBuilder.ToString();
                }
            }
        }
    }
