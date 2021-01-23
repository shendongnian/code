    public class Namespace : IDictionary<String, Namespace>
    {
        #region Static
        public static IEnumerable<Namespace> FromStrings(IEnumerable<String> namespaceStrings)
        {
            // Split all strings
            var splitSubNamespaces = namespaceStrings
                .Select(fullNamespace =>
                    fullNamespace.Split('.'));
            return FromSplitStrings(null, splitSubNamespaces);
        }
        public static IEnumerable<Namespace> FromSplitStrings(Namespace root, IEnumerable<IEnumerable<String>> splitSubNamespaces)
        {
            if (splitSubNamespaces == null)
                throw new ArgumentNullException("splitSubNamespaces");
            return splitSubNamespaces
                // Remove those split sequences that have no elements
                .Where(splitSubNamespace =>
                    splitSubNamespace.Any())
                // Group by the outermost namespace
                .GroupBy(splitNamespace =>
                     splitNamespace.First())
                // Create Namespace for each group and prepare sequences that represent nested namespaces
                .Select(group =>
                    new
                    {
                        Root = new Namespace(group.Key, root),
                        SplitSubnamespaces = group
                            .Select(splitNamespace =>
                                splitNamespace.Skip(1))
                    })
                // Select nested namespaces with recursive split call
                .Select(obj =>
                    new
                    {
                        Root = obj.Root,
                        SubNamespaces = FromSplitStrings(obj.Root, obj.SplitSubnamespaces)
                    })
                // Select only uppermost level namespaces to return
                .Select(obj =>
                    obj.Root)
                // To avoid deferred execution problems when recursive function may not be able to create nested namespaces
                .ToArray(); 
        }
        #endregion
        #region Fields
        private IDictionary<String, Namespace> subNamespaces;
        #endregion
        #region Constructors
        private Namespace(String nameOnLevel, Namespace parent)
        {
            if (String.IsNullOrWhiteSpace(nameOnLevel))
                throw new ArgumentException("nameOfLevel");
            this.Parent = parent;
            this.NameOnLevel = nameOnLevel;
            this.subNamespaces = new Dictionary<String, Namespace>();
            if (this.Parent != null)
            {
                this.Parent.Add(this.NameOnLevel, this);
            }
        }
        private Namespace(String nameOfLevel)
            : this(nameOfLevel, null)
        {
        }
        #endregion
        #region Properties
        public String NameOnLevel
        {
            get;
            private set;
        }
        public String FullName
        {
            get
            {
                if (this.Parent == null)
                    return this.NameOnLevel;
                return String.Format("{0}.{1}",
                    this.Parent.FullName,
                    this.NameOnLevel);
            }
        }
        private Namespace _Parent;
        public Namespace Parent
        {
            get
            {
                return this._Parent;
            }
            private set
            {
                if (this.Parent != null)
                    this.Parent.Remove(this.NameOnLevel);
                this._Parent = value;
            }
        }
        #endregion
        #region IDictionary implementation
        public void Add(string key, Namespace value)
        {
            if (this.ContainsKey(key))
                throw new InvalidOperationException("Namespace already contains namespace with such name on level");
            this.subNamespaces.Add(key, value);
        }
        public bool ContainsKey(string key)
        {
            return this.subNamespaces.ContainsKey(key);
        }
        public ICollection<string> Keys
        {
            get { return this.subNamespaces.Keys; }
        }
        public bool Remove(string key)
        {
            if (!this.ContainsKey(key))
                throw new KeyNotFoundException();
            this[key]._Parent = null;
            return this.subNamespaces.Remove(key);
        }
        public bool TryGetValue(string key, out Namespace value)
        {
            return this.subNamespaces.TryGetValue(key, out value);
        }
        public ICollection<Namespace> Values
        {
            get { return this.subNamespaces.Values; }
        }
        public ICollection<Namespace> Subnamespaces
        {
            get { return this.subNamespaces.Values; }
        }
        public Namespace this[string nameOnLevel]
        {
            get
            {
                return this.subNamespaces[nameOnLevel];
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("value");
                Namespace toReplace;
                if (this.TryGetValue(nameOnLevel, out toReplace))
                {
                    toReplace.Parent = null;
                }
                value.Parent = this;
            }
        }
        public void Add(KeyValuePair<string, Namespace> item)
        {
            this.Add(item.Key, item.Value);
        }
        public void Clear()
        {
            foreach (var subNamespace in this.subNamespaces.Select(kv => kv.Value))
            {
                subNamespace._Parent = null;
            }
            this.subNamespaces.Clear();
        }
        public bool Contains(KeyValuePair<string, Namespace> item)
        {
            return this.subNamespaces.Contains(item);
        }
        public void CopyTo(KeyValuePair<string, Namespace>[] array, int arrayIndex)
        {
            this.subNamespaces.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return this.subNamespaces.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(KeyValuePair<string, Namespace> item)
        {
            return this.subNamespaces.Remove(item);
        }
        public IEnumerator<KeyValuePair<string, Namespace>> GetEnumerator()
        {
            return this.subNamespaces.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return this.FullName;
        }
        #endregion
    }
