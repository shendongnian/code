        private void LoadXML()
        {
            try
            {
                XmlSerializer _serializer = new XmlSerializer(typeof(Codes));
    
                // A file stream is used to read the XML file into the ObservableCollection
                using (StreamReader _reader = new StreamReader(@"LocalCodes.xml"))
                {
                    CodeCollection.CollectionChanged -= OnCodeCollectionChanged;
                    CodeCollection = (_serializer.Deserialize(_reader) as Codes).CodeCollection;
                    CodeCollection.CollectionChanged += OnCodeCollectionChanged;
    
                }                
            }
