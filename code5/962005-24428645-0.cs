    try
            {
                
                throw new NullReferenceException("General null reference");
                
            }
            catch (Exception ex)
            {
                LogEntry logEntry = new LogEntry();
                logEntry.EventId = 100;
                logEntry.Priority = 2;
                logEntry.Message = "Informational message";
                Logger.Write(ex.ToString() + logEntry);
            }
