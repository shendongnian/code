    public void NewNote(string someText)
    {
    var note = new StickyNote();
    note.Activate();
    note.Activated += (s, e) => { note.Signal(someText); };
    }
