    public struct LetterInfo
    {
        public char Letter { get; set; }
        public int Occurence { get; set; }
        public int Index { get; set; }
        public override string ToString()
        {
            return string.Format("{0}:{1}->{2}", Index, Letter, Occurence);
        }
    }
