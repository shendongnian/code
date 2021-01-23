    class Windows1252Encoding : System.Text.Encoding {
        public override int GetByteCount(char[] chars, int index, int count) {
            return count;
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex) {
            Array.Copy(chars, charIndex, bytes, byteIndex, charCount);
            return charCount;
        }
        public override int GetCharCount(byte[] bytes, int index, int count) {
            return count;
        }
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex) {
            Array.Copy(bytes, byteIndex, chars, charIndex, byteCount);
            return byteCount;
        }
        public override int GetMaxByteCount(int charCount) {
            return charCount;
        }
        public override int GetMaxCharCount(int byteCount) {
            return byteCount;
        }
    }
