    class MusicalNote
    {
        public int Index { get; private set; }
        public string Name { get; private set; }
    
        private MusicalNote(int index, string name)
        {
            Index = index;
            Name = name;
        }
    
        public static readonly MusicalNote A = new MusicalNote(1, "A");
        public static readonly MusicalNote ASharp = new MusicalNote(2, "A#");
    }
