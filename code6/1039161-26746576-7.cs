    public static class TextReaderExtensions
    {
        public static IEnumerable<string> ReadLines(this TextReader sReader)
        {
            if (sReader == null)
                throw new ArgumentNullException();
            string line;
            while ((line = sReader.ReadLine()) != null)
                yield return line;
        }
    }
