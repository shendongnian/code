     public ObservableCollection<ParentNode> CreateTreeViewCollection(string ClassName)
        {
            EnumerateFullData AllData = new EnumerateFullData(ClassName);
        }
     public class EnumerateFullData
        {
            public EnumerateFullData (string className)
            { 
                ClassName  = className;
            }
            public string ClassName { get; set; }
            public List<PropertyData> Properties { get; set; }
        }
