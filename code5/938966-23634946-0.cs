    public class Piece
    {
        public Point Location {get; set;}
        public int Z {get; set;}
        public int ID {get; set;} // to be bound to control or a control itself?
        public Image Image {get; set;} // texture?
        public DockStyle PlusArea {get; set;}
        public DockStyle MinusArea {get; set;}  // can be None
        ...
        public bool HitTest(Point point)
        {
            // assuming all of same size
            if((new Rectangle(Location, new Size(...)).Contains(point))
            {
                switch(MinusArea)
                {
                    case Top:
                        if((new Rectangle(...)).Contains(point))
                            return false;
                    ...
                }
            }
            switch(MinusArea)
            {
                case Top:
                    if((new Rectangle(...)).Contains(point))
                        return true;
                ...
            }
            return false;
        }
