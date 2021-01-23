    public static class StringExtensions
    {
        public static string TrimEnd(this string str,
                                     string subject,
                                     StringComparison stringComparison)
        {
            var lastIndexOfSubject = str.LastIndexOf(subject, stringComparison);
            return (lastIndexOfSubject == -1
                    || (str.Length - lastIndexOfSubject) > subject.Length)
                ? str
                : str.Substring(0, lastIndexOfSubject);
        }
    }
