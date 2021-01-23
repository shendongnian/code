    public class Configurations
    {
        public TableProperties Property = new TableProperties();
        public void SaveSettings(){ }
        public Configurations LoadSettings(){ }
    }
    
    public class TableProperties
    {
        public int TableRow;
        public int TableColumn;
        public string TableName;
    }
