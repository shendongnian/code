    public class RootObject<T>
    {
        [XmlIgnore]
        public IEnumerable<T> Results { get; set; }
        [XmlArray("Results")]
        public EnumerableProxy<T> ResultsProxy { 
            get
            {
                return new EnumerableProxy<T> { BaseEnumerable = Results };
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
    public class TestClass
    {
        XmlWriter xmlWriter;
        TextWriter textWriter;
        public void Test()
        {
            try
            {
                var root = new RootObject<int>();
                root.Results = GetResults();
                using (textWriter = new StringWriter())
                {
                    var settings = new XmlWriterSettings { Indent = true, IndentChars = "  " };
                    using (xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        (new XmlSerializer(root.GetType())).Serialize(xmlWriter, root);
                    }
                    var xml = textWriter.ToString();
                    Debug.WriteLine(xml);
                }
            }
            finally
            {
                xmlWriter = null;
                textWriter = null;
            }
        }
        IEnumerable<int> GetResults()
        {
            foreach (var i in Enumerable.Range(0, 1000))
            {
                if (i > 0 && (i % 500) == 0)
                {
                    HalfwayPoint();
                }
                yield return i;
            }
        }
        private void HalfwayPoint()
        {
            if (xmlWriter != null)
            {
                xmlWriter.Flush();
                var xml = textWriter.ToString();
                Debug.WriteLine(xml);
            }
        }
    }
