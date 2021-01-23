    class Document {
        public string Key { get; set; }
    }
    class Track : Document {}
    class Album : Document { }
    
    class CellWrapper<T> where T : Document {
        public T Document { get; set; }
    }
     
    class TableViewSource
    {
     
        public void CreateCellForItem(object item)
        {
            var documentProperty = item.GetType().GetProperty("Document");
            var document = (Document)documentProperty.GetValue(item);
            Console.WriteLine(document.Key);
        }
    }
