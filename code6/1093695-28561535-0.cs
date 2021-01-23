    interface ILink
    {
        static string ID { get; }
    }
    class OpenDocumentLink : ILink
    {
        public static string ID { get { return "DOCUMENT_OPEN"; } }
    }
