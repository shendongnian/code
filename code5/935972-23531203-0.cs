    public class Board
    {
        public List<Row> Rows = new List<Row>();
        public override bool Equals(object obj)
        {
            var board = obj as Board;
            if (board == null)
                return false;
            if (board.Rows.Count != Rows.Count)
                return false;
            return !board.Rows.Where((t, i) => !t.Equals(Rows[i])).Any();
        }
        public override int GetHashCode()
        {
            // determine what's appropriate to return here - a unique board id may be appropriate if available
        }
    }
    
    public class Row
    {
        public List<int> Cells = new List<int>(); 
        public override bool Equals(object obj)
        {
            var row = obj as Row;
            if (row == null)
                return false;
            if (row.Cells.Count != Cells.Count)
                return false;
            if (row.Cells.Except(Cells).Any())
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            // determine what's appropriate to return here - a unique row id may be appropriate if available
        }
    }
