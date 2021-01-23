    public struct WordStruct : ICloneable 
    {
        public char C;
        public WordStruct(char C) 
        {
            this.C = C;
        }
        public object Clone()
        {
            WordStruct newWordStruct = (WordStruct)this.MemberwiseClone();
            return newWordStruct;
        }
    }
