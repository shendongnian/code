        public static List<string> TimeGet(List<string> heatList, TimeSpan startTimeSpan, TimeSpan timeGap)
        {
            return heatList
                .Select(x =>
                    startTimeSpan.Add(TimeSpan.FromMinutes(timeGap.Minutes*(int.Parse(x.Substring(1)) - 1)))
                        .ToString(@"hh\:mm")).ToList();
        }
