    public class WSDLReport
    {
        private IEnumerable<WSDLDocument> _document;
        private void SetDocuments(dynamic documents)
        {
            var type = documents.GetType();
            if (type == typeof(JObject))
                _document = new List<WSDLDocument>() { ((JObject)documents).ToObject<WSDLDocument>() };
            else if (type == typeof(JArray))
                _document = ((JArray)documents).ToObject<IEnumerable<WSDLDocument>>();
            else
                _document = new List<WSDLDocument>();
        }
        private dynamic GetDocuments() => _document;
        [JsonProperty("dokumentyEzla")]
        public dynamic Document
        {
            get => GetDocuments();
            set => SetDocuments(value);
        }
    }
