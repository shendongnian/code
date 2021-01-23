    // Code kept as short as possible, ctors and error checking are omitted
    class Cell
    {
        string Content {get;set;}
    }
    
    class Row
    {
        List<Cell> Cells {get;set;}
    }
    
    class Table
    {
        List<Row> Rows {get;set;}
    }
