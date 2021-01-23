    public class BitTest
    {
        private int[] _data;
        public BitTest(int[] data)
        {
            Length = data.Length * 4 * 8;
            // +2, because we use byte* and long* later
            // and don't want to read outside the array memory
            _data = new int[data.Length + 2];
            Array.Copy(data, _data, data.Length);
        }
        public int Position { get; private set; }
        public int Length { get; private set; }
