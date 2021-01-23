    using System;
    using ms = Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    
    namespace LoggingService
    {
        public static class Logger
        {
            static Logger()
            {
                try
                {
                    IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                    ms.LogWriterFactory logWriterFactory = new ms.LogWriterFactory(configurationSource);
                    ms.Logger.SetLogWriter(new ms.LogWriterFactory().Create());
                }
                catch (Exception)
                {
                }
            }
            /// <summary>
            /// Writes exception details to the log using Enterprise Library
            /// </summary>
            /// <param name="ex"></param>
            public static void Log(Exception ex)
            {
    // can be changed as per your requirement for the event/priority and the category
                ms.Logger.Write(ex, "ErrorsWarnings", 1, 1, System.Diagnostics.TraceEventType.Error);
            }
            /// <summary>
            /// Writes Information message to the log using Enterprise Library
            /// </summary>
            /// <param name="infoMsg"></param>
            public static void Log(string infoMsg)
            {
                ms.Logger.Write(infoMsg);
            }
        }
    }
