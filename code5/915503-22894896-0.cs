    public class PaddedInteger
    {
        private int Value { get; set; }
        private int PaddingSize { get; set; }
        private char PaddingCharacter { get; set; }
        public PaddedInteger(int value, int paddingSize, char paddingCharacter)
        {
            Value = value;
            PaddingSize = paddingSize;
            PaddingCharacter = paddingCharacter;
        }
        public override string ToString()
        {
            return Convert.ToString(Value).PadLeft(PaddingSize, PaddingCharacter);
        }
    }
