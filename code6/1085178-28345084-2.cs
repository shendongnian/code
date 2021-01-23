        public override System.Windows.ResourceDictionary[] ResourceDictionaries
        {
            get
            {
                var strings = CollectionAdapters.ToIList<string>(_contract.ResourceDictionaries);
                var rds = new List<System.Windows.ResourceDictionary>();
                foreach (var s in strings)
                {
                    var output = XamlReader.Parse(s);
                    if ((output as System.Windows.ResourceDictionary) != null)
                        rds.Add(output as System.Windows.ResourceDictionary);
                }
                return rds.ToArray();
            }
        }
