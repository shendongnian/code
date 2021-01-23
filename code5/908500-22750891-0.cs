    class Cell
    {
        private Mark markType = Mark.Empty; 
        private IGameViewer viewer;
        public static event EventHandler CellChanged; 
        public readonly Tuple<int, int> pos;
    
        public Cell(IGameViewer viewer, Tuple<int, int> coords)
        {
            this.viewer = viewer;
            this.pos = coords;
            viewer.DisplayCell(this);
        }
        public Mark MarkType { 
            get { return markType; } 
            set 
            {
                // Only allow changes to cells without a mark 
                if (markType.Equals(Mark.Empty)) 
                {    
                    markType = value;
                    OnCellChanged();
                }      
            } 
        }
        protected virtual void OnCellChanged()
        {
            var handler = this.CellChanged;
            if (handler)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
