            var logs = new List<LogEntry>
            {
                new LogEntry(new DateTime(2015, 3, 5, 11, 10, 15), true),
                new LogEntry(new DateTime(2015, 3, 5, 11, 20, 15), false),
                new LogEntry(new DateTime(2015, 3, 5, 12, 30, 15), true),
                new LogEntry(new DateTime(2015, 3, 5, 13, 40, 15), false),
                new LogEntry(new DateTime(2015, 3, 5, 14, 50, 15), true),
                new LogEntry(new DateTime(2015, 3, 5, 15, 10, 15), false)
            };
            var results = new List<ResultEntry>();
            for (var i = 1; i < logs.Count; i++)
            {
                var logEntry = logs[i];
                DateTime startDateTime;
                DateTime endDateTime;
                var roundedStartDateTime = new DateTime(logEntry.DateTime.Year, logEntry.DateTime.Month,
                    logEntry.DateTime.Day, logEntry.DateTime.Hour, 0, 0);
                var roundedEndDateTime = roundedStartDateTime.AddHours(1);
                if (logEntry.Status)
                {
                    startDateTime = logEntry.DateTime;
                    endDateTime = roundedEndDateTime;
                    if (i < logs.Count - 1)
                    {
                        var nextLogEntry = logs[i + 1];
                        endDateTime = roundedEndDateTime < nextLogEntry.DateTime
                            ? roundedEndDateTime
                            : nextLogEntry.DateTime;
                    }
                }
                else
                {
                    var previousLogEntry = logs[i - 1];
                    startDateTime = roundedStartDateTime > previousLogEntry.DateTime
                        ? roundedStartDateTime
                        : previousLogEntry.DateTime;
                    endDateTime = logEntry.DateTime;
                }
                var minutesOn = Convert.ToInt32((endDateTime - startDateTime).TotalMinutes);
                results.Add(new ResultEntry(roundedStartDateTime, minutesOn));
            }
