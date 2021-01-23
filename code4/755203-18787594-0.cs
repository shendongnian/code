     class MyXmlReader
    {
        // refference to current list element
        XmlNode currentListElement = null;
        XmlDocument xml;
        // load file, initialize  and return data that contains info ablut
        // the first level elements names
        public DataElement Load(string path)
        {
            xml = new XmlDocument();
            xml.Load(path);
            Init();
            DataElement result = new DataElement();
            result.SubTitles = GetChildTitles();
            return result;
        }
        // Initialize the reader to read from the beggining
        public void Init()
        {
            currentListElement = xml.DocumentElement;
        }
        // Get next child
        public DataElement GetNext(string title)
        {
            string tempTitle;
            foreach (XmlNode child in currentListElement.ChildNodes)
            {
                DataElement result = null;
                if (child.Attributes["Title"].Value == title)
                {
                    // create object that contains the data about the child nodes Titles
                    result = new DataElement();
                    result.Title = child.Attributes["Title"].Value;
                    if (child.FirstChild != null) // means no child nodes
                    {
                        currentListElement = child.FirstChild;
                        // add subelements subtitles
                        result.SubTitles.AddRange(GetChildTitles());
                    }
                    return result;
                }
            }
            return null;
        }
        public List<string> GetChildTitles()
        {
            List<string> result = new List<string>();
            foreach (XmlNode child in currentListElement.ChildNodes)
            {
                result.Add(child.Attributes["Title"].Value);
            }
            return result;
        }
    }
    // add any other data to this class
    // that you need about the element you return
    class DataElement
    {
        public List<string> SubTitles = new List<string>();
        public string Title { get; set; }
    }
