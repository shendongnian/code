    delegate void RemoveNoteDelegate(Note note);
    class Bar
    {
        private List<Note> notes; 
        public Bar()
        {
            notes = new List<Note>(0);
            notes.Add(new Note(removeNote))
        }
    
        public void removeNote(Note note)
        {
            notes.Remove(note);
        }
    }
    class Note
    {   
        public RemoveNoteDelegate remove_Note;
     
        public Note(RemoveNoteDelegate remove_Note)
        {
            //do stuff
            remove_Note(this);
        }
    }
    public MainWindow()
    {
        private Bar newBar = new Bar();
    }
