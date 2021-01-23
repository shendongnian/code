        //This is just a demo without check for valid cell (with RowIndex and ColumnIndex in range)
        public class CustomDataTable : DataTable
        {
            public Dictionary<Cell, Control> CellBindings { get; private set; }
            public CustomDataTable()
            {
                CellBindings = new Dictionary<Cell, Control>();
            }
            protected override void OnColumnChanged(DataColumnChangeEventArgs e)
            {                
                Cell cell = new Cell {RowIndex = Rows.IndexOf(e.Row), ColumnIndex = e.Column.Ordinal};
                Control c;
                if (CellBindings.TryGetValue(cell, out c))
                {
                    c.Text = e.Row[e.Column].ToString();
                }
                base.OnColumnChanged(e);
            }
            public struct Cell
            {
                public int RowIndex { get; set; }
                public int ColumnIndex { get; set; }
                public Cell(int rowIndex, int colIndex) : this()
                {
                    RowIndex = rowIndex;
                    ColumnIndex = colIndex;
                }
            }
        }
        //Use it
        //Bind cell at (2,0) to the textBox1
        customDataTable.CellBindings.Add(new CustomDataTable.Cell(2, 0), textBox1);
