    public class MyXmlNamespaceManager : XmlNamespaceManager
    {
        const string DefaultMissingNamespacePrefix = "http://missing.namespace.prefix.net/2014/";
        private string MissingNamespacePrefix { get; set; }
        private int NextMissingNamespaceIndex { get; set; }
        // The dictionary consists of a collection of namespace names keyed by prefix.
        public Dictionary<string, List<string>> MissingNamespaces { get; private set; }
        public MyXmlNamespaceManager(XmlNameTable nameTable)
            : this(nameTable, null) { }
        public MyXmlNamespaceManager(XmlNameTable nameTable, string missingNamespacePrefix)
            : base(nameTable)
        {
            this.MissingNamespacePrefix = (string.IsNullOrEmpty(missingNamespacePrefix) ? DefaultMissingNamespacePrefix : missingNamespacePrefix);
            this.MissingNamespaces = new Dictionary<string, List<string>>();
        }
        void AddMissingNamespace(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
                return;
            string uri;
            do
            {
                int index = NextMissingNamespaceIndex++;
                uri = MissingNamespacePrefix + index.ToString();
            }
            while (LookupPrefix(uri) != null); // Just in case.
            Debug.WriteLine(string.Format("Missing namespace \"{0}\" found, added fake namespace \"{1}\"", prefix, uri));
            AddNamespace(prefix, uri);
            MissingNamespaces.Add(prefix, uri);
        }
        public override bool HasNamespace(string prefix)
        {
            var result = base.HasNamespace(prefix);
            if (!result)
                AddMissingNamespace(prefix);
            result = base.HasNamespace(prefix);
            return result;
        }
        public override string LookupNamespace(string prefix)
        {
            var result = base.LookupNamespace(prefix);
            if (result == null)
                AddMissingNamespace(prefix);
            result = base.LookupNamespace(prefix);
            return result;
        }
    }
    public static class DictionaryExtensions
    {
        public static void Add<TKey, TValue>(this IDictionary<TKey, List<TValue>> listDictionary, TKey key, TValue value)
        {
            if (listDictionary == null)
                throw new ArgumentNullException();
            List<TValue> values;
            if (!listDictionary.TryGetValue(key, out values))
            {
                listDictionary[key] = values = new List<TValue>();
            }
            values.Add(value);
        }
    }
