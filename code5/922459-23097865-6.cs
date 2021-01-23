    public abstract class RowOperation {
        public void apply(string status, Row row) {
            switch(status)
            {
                case: "Old"
                    this.OldCase(row);
                    break;
                case: "New"
                    this.NewCase(row);
                    break;
                default:
                    this.OtherCase(row);
                    break;
            }
        }
        abstract void OldCase(Row);
        abstract void NewCase(Row);
        abstract void OtherCase(Row);
    }
    
    public class ColorRow implements RowOperation {
        private static final ColorCells OP = new ColorCells();
        private ColorCells(){}
        // This operation isn't stateful so we use a singleton :D
        public static RowOperation getInstance() {
            return this.OP
        }
        public void OldCase(row) {
            row.BackColor = Color.Red;
        }
        public void NewCase(row) {
            row.BackColor = Color.Blue;
        }
        public void OtherCase(row) {
            row.BackColor = Color.White;
        }
    }
    
    public class CountRow implements CellOperation {
        public int oldRows = 0;
        public int newRows = 0;
        public int otherRows= 0;
        // This operation is stateful so we use the contructor
        public CountRow() {}
        public void OldCase(Row row) {
            oldRows++;
        }
        public void NewCase(Row row) {
            newRows++;
        }
        public void OtherCase(Row row) {
            otherRows++;
        }
    }
    
    // For each row in the grid we will call each operation
    // function with the row status and the row
    void UpdateRows(Grid grid, RowOperation[] operations)
    {
        foreach(Row row in grid.Rows)
        {
            string status = row.Cells["Status"]
    
            foreach(RowOperation op in operations)
            {
                op.apply(status, row)
            }
        }
    }
