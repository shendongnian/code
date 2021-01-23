    private IEnumerable<Note> _noteGrid
    public IEnumerable<Note> NoteGrid 
    {
        get { return _noteGrid; } 
        private set { _noteGrid = value; Notify("NoteGrid "); }
    }
