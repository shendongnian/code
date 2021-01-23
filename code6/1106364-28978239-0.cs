    public class Column
    {
        [Range(1, 9, ErrorMessage = "Please enter a value between 1 and 9")]
        public int Value { get; set; }
    }
    public class Row
    {
        public Row()
        {
            Columns = Enumerable.Repeat(new Column(), 9).ToList();
        }
        public List<Column> Columns { get; set; }
    }
    public class Grid
    {
        public  Grid()
        {
            Rows = Enumerable.Repeat(new Row(), 9).ToList();
        }
        public List<Row> Rows { get; set; }
    }
