    [System.Xml.Serialization.XmlRoot("paddedLogEntry")]
    [Serializable]
    public class PaddedLogEntry : LogEntry
    {
        public string PaddedSeverity
        {
            get
            {
                return this.Severity.ToString().PadRight(11);
            }
        }
    }
    LogWriter logger = new LogWriterFactory().Create();
    PaddedLogEntry logEntry1 = new PaddedLogEntry()
    {
        Message = "Testing 123...",
        Severity = System.Diagnostics.TraceEventType.Information
    };
    logEntry1.Categories.Add("General");
    logger.Write(logEntry1);
