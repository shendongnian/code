        internal const string NodeStart = "<Error ";
        public static bool IsErrorDocument(string xml)
        {
            int headerLen = 1;
            if (xml.StartsWith(Constants.XMLHEADER_UTF8))
            {
                headerLen += Constants.XMLHEADER_UTF8.Length;
            }
            else if (xml.StartsWith(Constants.XMLHEADER_UTF16))
            {
                headerLen += Constants.XMLHEADER_UTF16.Length;
            }
            else
            {
                return false;
            }
            if (xml.Length < headerLen + NodeStart.Length)
            {
                return false;
            }
            return xml.Substring(headerLen, NodeStart.Length) == NodeStart;
        }
    internal class Constants
    {
        public const string XMLHEADER_UTF16 = "<?xml version=\"1.0\" encoding=\"utf-16\"?>";
        public const string XMLHEADER_UTF8 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
    }
