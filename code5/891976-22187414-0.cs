    public interface IPlayable
    {
        void Play();
    }
    class Bar : IPlayable
    {
        private IList<Note> notes = new List<Note> { new Note() }; 
        public void Play() 
        {
            foreach (var note in notes)
            {
                note.Play();
            }
        }
    }
    class Note : IPlayable
    {        
        public Note()
        {
            //do stuff
        }
        public void Play() { /* ... */ }
    }
