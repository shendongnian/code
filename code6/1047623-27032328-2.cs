    public class Cell 
    {
        public Cell() {}
        public Cell(Cell other)
        {
            this.Text = other.Text;
        }
        [XmlText]
        public string Text { get; set; }
    }
    public class XmlCell : Cell // For serialization
    {
        public XmlCell() : base() {}
        public XmlCell(Cell other, int index) : base(other)
        {
            this.Index = index;
        }
        [XmlAttribute("INDEX")]
        public int Index { get; set; }
    }
    [XmlRoot("ROW")]
    public class Row
    {
        List<Cell> cells;
        [XmlIgnore]
        public List<Cell> Cells
        {
            get
            {
                if (cells == null)
                    Interlocked.CompareExchange(ref cells, new List<Cell>(), null);
                return cells;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlElement("CELL")]
        public XmlCell[] XmlCells // proxy array for serialization.
        {
            get
            {
                var xmlCells = new XmlCell[Cells.Count];
                for (int iCell = 0; iCell < xmlCells.Length; iCell++)
                    xmlCells[iCell] = new XmlCell(Cells[iCell], iCell);
                return xmlCells;
            }
            set
            {
                Cells.Clear();
                foreach (var xmlCell in value)
                {
                    Cells.EnsureCount(xmlCell.Index + 1);
                    Cells[xmlCell.Index] = new Cell(xmlCell);
                }
            }
        }
    }
