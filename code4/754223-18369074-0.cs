                //Lets get those log entries!
            List<string> logEntries = new List<string>(); // Create a list array to hold each entry
            List<string> logTimes = new List<string>(); // Create a list array to hold each log time
            foreach (XPathNavigator entry in runningLogTable) // iterate through the repeating section of the log
            {
                logEntry = entry.SelectSingleNode("@my:entry", this.NamespaceManager).Value; // Get the string value from each field
                logTime = entry.SelectSingleNode("my:CurrentTime", this.NamespaceManager).Value; // Get the string value for the time from each field.
                logEntries.Add(logEntry); // Add each log entry to the list starting at position (index) 0
                logTimes.Add(convertTime(logTime)); // Add each time entry to the list starting at position (index) 0
                // Each log entry should align with the correct time entry since both start at index 0.
            }
            for (int i = (logEntries.Count - 1); i >= 0; i--) // get the count of the log entries list and loop through each indexed position in reverse.
            {
                sb.Append(logTimes[i].ToString() + "\n"); // append each indexed entry to the log starting from the last position and moving to the first (0)
                sb.Append(logEntries[i].ToString() + "\n\n"); // append each indexed time to the log starting from the last position and moving to the first (0)
            }
