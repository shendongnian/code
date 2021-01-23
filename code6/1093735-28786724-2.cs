    public class Artist
    {    
        public List<Painting> Paintings { get; private set; }    
        public Artist()
        {
            this.Paintings = new List<Painting>();
        }
    }
