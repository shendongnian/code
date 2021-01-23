    public class Cells
    {
        public Cells(Cell[] cells)
        {
            
        }
        public static Cells getCells(params Cell[] cells)
        {
            return new Cells(cells);
        }
    }
