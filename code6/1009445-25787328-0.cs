    public struct Key
    {
        public readonly string  Name;
        public readonly int     Rating;
    
        public Key(string name, int rating){
            Name = name;
            Rating = rating;
        }
    }
    // useage (needs compiler magic)
    var key = new Key("MonorailCat", 5);
