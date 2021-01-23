        internal string GetTime(string line)
        {
            // ...
            string tmp = time.Substring(0, 12);
            time = DateTime.ParseExact(tmp, "HH:mm:ss:fff", CultureInfo.CurrentUICulture).Ticks.ToString();
            return time;
        }
