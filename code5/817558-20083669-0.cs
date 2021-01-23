    public class PalyndromeGenerator
    {
        private List<string> _results;
        private bool _isGenerated;
        private int _length;
        private char[] _characters;
        private int _middle;
        private char[] _currentItem;
        public PalyndromeGenerator(int length, params char[] characters)
        {
            if (length <= 0)
                throw new ArgumentException("length");
            if (characters == null)
                throw new ArgumentNullException("characters");
            if (characters.Length == 0)
                throw new ArgumentException("characters");
            _length = length;
            _characters = characters;
        }
        public List<string> Results
        {
            get
            {
                if (!_isGenerated)
                    throw new InvalidOperationException();
                return _results.ToList();
            }
        }
        public void Generate()
        {
            _middle = (int)Math.Ceiling(_length / 2.0) - 1;
            _results = new List<string>((int)Math.Pow(_characters.Length, _middle + 1));
            _currentItem = new char[_length];
            GeneratePosition(0);
            _isGenerated = true;
        }
        private void GeneratePosition(int position)
        {
            if(position == _middle)
            {
                for (int i = 0; i < _characters.Length; i++)
                {
                    _currentItem[position] = _characters[i];
                    _currentItem[_length - position - 1] = _characters[i];
                    _results.Add(new string(_currentItem));
                }
            }
            else
            {
                for(int i = 0; i < _characters.Length; i++)
                {
                    _currentItem[position] = _characters[i];
                    _currentItem[_length - position - 1] = _characters[i];
                    GeneratePosition(position + 1);
                }
            }
        }
    }
