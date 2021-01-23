        [XmlArrayItem(ElementName = "Meter")]
        [XmlArray(ElementName = "Meters")]
        public ObservableCollection<Meter> SerializableMeters
        {
            get
            {
                Debug.WriteLine("Returning proxy SerializableMeters");
                var list = new ObservableCollection<Meter>(Meters.Cast<Meter>());
                list.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(list_CollectionChanged);
                return list;
            }
            set
            {
                Debug.WriteLine("Setting proxy SerializableMeters");
                Meters = new List<IMeter>(value.Cast<IMeter>());
            }
        }
        static void list_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var collection = (IList<Meter>)sender;
            Debug.WriteLine("Proxy collection changed to include : ");
            foreach (var item in collection)
                Debug.WriteLine("   " + item.ToString());
        } 
