            try
            {
                EventLog.WriteEntry("LogSource", "test", EventLogEntryType.Error, 6285);
            }
            catch
            {
                MessageBox.Show("Could not write to log.");
            }
