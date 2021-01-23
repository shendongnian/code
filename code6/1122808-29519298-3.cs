    public class ColumnMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InputColumnMapping : ColumnMapping
    {
        public int MappsToId { get; set; }
    }
    public class Mapping<T> where T : ColumnMapping
    {
        [XmlAttribute]
        public string TableName { get; set; }
        public List<T> Columns { get; set; }
    }
    public class RemoteMapping
    {
        public Column TableNames { get; set; }
        public List<Column> Columns { get; set; }
    }
    
    public class Column
    {
        [XmlAttribute]
        public string Source { get; set; }
    
    [XmlAttribute]
        public string Destination { get; set; }
    }
    public class RemoteMappingFile
    {
        [XmlAttribute]
        public string SSISName { get; set; }
        public List<RemoteMapping> RemoteMappings { get; set; }
    }
    public class MappingsXml
    {
        public List<RemoteMappingFile> Mappings { get; set; }
    }
