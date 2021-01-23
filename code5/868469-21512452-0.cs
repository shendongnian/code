    public class Block
    {
        public const int Size = 8;
        private float[,] _values;
        public float this[int x, int y]
        {
            get { return _values[y, x]; }
            set { _values[y, x] = value; }
        }
        public Block(float value)
        {
            //Initialize all cells with the given value, this makes it easier to demo the code.
            _values = new float[Size, Size];
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                    _values[y, x] = value;
            }
        }
        public string[] TextLines
        {
            get
            {
                List<string> lines = new List<string>();
                for (int y = 0; y < Size; y++)
                {
                    StringBuilder sbLine = new StringBuilder();
                    for (int x = 0; x < Size; x++)
                        sbLine.AppendFormat("{0:00} ", _values[y, x]);
                    lines.Add(sbLine.ToString());
                }
                return lines.ToArray();
            }
        }
    }
