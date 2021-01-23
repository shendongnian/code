    public static class Helper
    {
        public static IEnumerable<String> ExtractSegments(this Uri uri, String exclusiveStart)
        {
            bool startFound = false;
            foreach (var seg in uri.Segments.Select(i => i.Replace(@"/","")))
            {
                if (startFound == false)
                {
                    if (seg == exclusiveStart)
                        startFound = true;
                }
                else
                {
                    if (!seg.Contains("."))
                        yield return seg;
                }
            }
        }
    }
