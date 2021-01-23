    public void Main()
    {
    	Bar newBar = new Bar(true);
    }
    
    // Define other methods and classes here
    class Bar
    {
        List<Note> notes; 
    
        public Bar(bool instantiate)
        {
    		if(instantiate) {
    			notes = new List<Note>(0);
    			notes.Add(new Note());
    		}
        }
    }
    
    class Note : Bar
    {        
        public Note() : base(false)
        {
            //do stuff
        }
    }
