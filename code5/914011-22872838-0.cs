        private TimeZoneInfo ConvertTimeZone(string timeZoneString)
        {
            ReadOnlyCollection<TimeZoneInfo> timeZoneInfos = TimeZoneInfo.GetSystemTimeZones();
            if (Regex.IsMatch(timeZoneString, "[A-Z]{3,5}[0-9]{0,2}") && !Regex.IsMatch(timeZoneString, "[A-Z]{3,5}[-]{1}[0-9]{0,2}"))
            {
                List<string> abbreviations = new List<string>();
                // create the list of abbreviations for TimeZoneInfos
                timeZoneInfos.ToList().ForEach(
                    x =>
                {
                    if (!Regex.IsMatch(x.StandardName, "[A-Z0-9]{3,4,5}"))
                    {
                        string fullString = x.StandardName.Replace(" ", string.Empty);
                        string[] split = Regex.Split(fullString, "[a-z]|[()-.]");
                        abbreviations.Add(string.Concat(split));
                    }
                });
                return timeZoneInfos[abbreviations.IndexOf(timeZoneString)];
            }
            else
            {
                return timeZoneInfos.Where(x => x.StandardName == timeZoneString).First();
            }
        }
