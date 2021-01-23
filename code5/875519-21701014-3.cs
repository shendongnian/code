    // Code kept short, minimal ctors
    public class Cell
    {
        public string Content {get;set;}
        public Cell() { this.Content = string.Empty; }
    }
    
    public class Row
    {
        public List<Cell> Cells {get;set;}
        public Row() { this.Cells = new List<Cell>(); }
    }
    
    public class Table
    {
        public List<Row> Rows {get;set;}
        public Table() { this.Rows = new List<Row>(); }
    }
