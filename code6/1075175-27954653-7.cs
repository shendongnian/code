    [Serializable]
    [DataContract]
    public class TestConfiguration
    {
        [DataMember]
        public String Name { get { return mName; } set { mName = value; } }
        
        private String mName = "Pete Sebeck";
        [DataMember]
        public ObservableCollection<String> Associates
        {
            get
            {
                Debug.WriteLine(mAssociates == null ? "Associates gotten, null value" : "Associates gotten, count = " + mAssociates.Count.ToString());
                return mAssociates;
            }
            set
            {
                Debug.WriteLine(value == null ? "Associates set to a null value" : "Associates set, count = " + value.Count.ToString());
                RemoveListeners(mAssociates);
                mAssociates = AddListeners(value);
            }
        }
        private ObservableCollection<String> mAssociates = AddListeners(new ObservableCollection<string>() { "Jon", "Natalie" });
        public override String ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine(String.Format("Name: {0}", Name));
            buffer.AppendLine("Associates:");
            foreach (String associate in mAssociates)
            {
                buffer.AppendLine(String.Format("\t{0}", associate));
            }
            return buffer.ToString();
        }
        static ObservableCollection<String> AddListeners(ObservableCollection<String> list)
        {
            if (list != null)
            {
                list.CollectionChanged -= list_CollectionChanged; // In case it was already there.
                list.CollectionChanged += list_CollectionChanged;
            }
            return list;
        }
        static ObservableCollection<String> RemoveListeners(ObservableCollection<String> list)
        {
            if (list != null)
            {
                list.CollectionChanged -= list_CollectionChanged; // In case it was already there.
            }
            return list;
        }
        public static ValueWrapper<bool> ShowDebugInformation = new ValueWrapper<bool>(false);
        static void list_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!ShowDebugInformation)
                return;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Debug.WriteLine(string.Format("Added {0} items", e.NewItems.Count));
                    break;
                case NotifyCollectionChangedAction.Move:
                    Debug.WriteLine("Moved items");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Debug.WriteLine(string.Format("Removed {0} items", e.OldItems.Count));
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Debug.WriteLine("Replaced items");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Debug.WriteLine("Reset collection");
                    break;
            }
        }
    }
    public static class TestTestConfiguration
    {
        public static void Test()
        {
            var test = new TestConfiguration();
            Debug.WriteLine("\nTesting Xmlserializer...");
            var xml = XmlSerializationHelper.GetXml(test);
            using (new SetValue<bool>(TestConfiguration.ShowDebugInformation, true))
            {
                var testFromXml = XmlSerializationHelper.LoadFromXML<TestConfiguration>(xml);
                Debug.WriteLine("XmlSerializer result: " + testFromXml.ToString());
            }
            Debug.WriteLine("\nTesting Json.NET...");
            var json = JsonConvert.SerializeObject(test, Formatting.Indented);
            using (new SetValue<bool>(TestConfiguration.ShowDebugInformation, true))
            {
                var testFromJson = JsonConvert.DeserializeObject<TestConfiguration>(json);
                Debug.WriteLine("Json.NET result: " + testFromJson.ToString());
            }
            Debug.WriteLine("\nTesting DataContractSerializer...");
            var contractXml = DataContractSerializerHelper.GetXml(test);
            using (new SetValue<bool>(TestConfiguration.ShowDebugInformation, true))
            {
                var testFromContractXml = DataContractSerializerHelper.LoadFromXML<TestConfiguration>(contractXml);
                Debug.WriteLine("DataContractSerializer result: " + testFromContractXml.ToString());
            }
            Debug.WriteLine("\nTesting BinaryFormatter...");
            var binary = BinaryFormatterHelper.ToBase64String(test);
            using (new SetValue<bool>(TestConfiguration.ShowDebugInformation, true))
            {
                var testFromBinary = BinaryFormatterHelper.FromBase64String<TestConfiguration>(binary);
                Debug.WriteLine("BinaryFormatter result: " + testFromBinary.ToString());
            }
            Debug.WriteLine("\nTesting JavaScriptSerializer...");
            var javaScript = new JavaScriptSerializer().Serialize(test);
            using (new SetValue<bool>(TestConfiguration.ShowDebugInformation, true))
            {
                var testFromJavaScript = new JavaScriptSerializer().Deserialize<TestConfiguration>(javaScript);
                Debug.WriteLine("JavaScriptSerializer result: " + testFromJavaScript.ToString());
            }
        }
    }
