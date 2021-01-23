    private List<Note> _Notes;
    public List<Note> Notes
    {
        get
        {
            return _Notes ?? new List<Note>();
        }
        set
        {
            _Notes = value;
        }
    }
