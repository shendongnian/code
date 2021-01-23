    public class OpeningDataTable : Autodesk.AutoCAD.DatabaseServices.Table
    {
        private Table _table; // the decorated Table
    
        public OpeningDataTable(Table table)
        {
            _table = table;
        }
    
        // <your methods for working with the decorated Table
    }
