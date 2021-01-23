    public class Column
    {
        public Column()
        {
            Cells = new List<Cell>();
        }
        public string Title { get; set; }
        public List<Cell> Cells { get; set; }
    }
    public class Cell
    {
        public int Value { get; set; }
    }
