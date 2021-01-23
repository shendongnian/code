    using System.Text.RegularExpressions;
    namespace StackOverflow
    {
        class Demo
        {
            /* ... */
            readonly Regex timeFormat = new Regex(@"^(?:(?:[0-1][0-9])|2[0-3]):[0-5][0-9]:[0-5][0-9]$", RegexOptions.Compiled);
            public bool IsTimeFormatValid(string time)
            {
                return timeFormat.IsMatch(time);
            }
            /* ... */
        }
    }
