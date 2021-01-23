    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    namespace ConsoleApplication
    {
        [Serializable]
        public class DimensionInfo
        {
            [XmlElement("enabled")]
            public Boolean Enabled { get; set; }
            public DimensionInfo()
            {
                Enabled = false;
            }
        }
        [Serializable]
        [XmlRoot("metadata")]
        public class Metadata
        {
            [XmlElement("entry")]
            public List<Entry> Entries { get; set; }
            public Metadata()
            {
                Entries = new List<Entry>();
            }
        }
        [Serializable]
        public class Entry
        {
            private DimensionInfo _dimensionInfo = default(DimensionInfo);
            private Boolean _containsDimensionInfo = true;
            [XmlAttribute("key")]
            public String Key { get; set; }
            [XmlText(typeof(String))]
            public String ContainsDimensionInfo
            {
                get
                {
                    return CheckDimensionContaining().ToString().ToLower();
                }
                set
                {
                    _containsDimensionInfo = Boolean.Parse(value);
                }
            }
            [XmlIgnore]
            public Boolean ContainsDimensionInfoSpecified
            {
                get { return !CheckDimensionContaining(); }
            }
            [XmlElement("dimensionInfo")]
            public DimensionInfo DimensionInfo
            {
                get { return _dimensionInfo; }
                set { _dimensionInfo = value; }
            }
            [XmlIgnore]
            public Boolean DimensionInfoSpecified
            {
                get { return CheckDimensionContaining(); }
            }
            public Entry()
            {
                Key = String.Empty;
                CheckDimensionContaining();
            }
            private Boolean CheckDimensionContaining()
            {
                return _containsDimensionInfo = _dimensionInfo != default(DimensionInfo);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Metadata metadata = new Metadata();
                metadata.Entries.Add(new Entry()); //Adding empty entry
                //Adding entry with info
                metadata.Entries.Add(new Entry() { DimensionInfo = new DimensionInfo() });
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Metadata));
                using (FileStream fileStream = new FileStream("info.txt", FileMode.Create))
                {
                    xmlSerializer.Serialize(fileStream, metadata);
                    fileStream.Position = 0;
                }
            }
        }
    }
