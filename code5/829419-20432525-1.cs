    public class Sequencer
    {
        public string characterDictionary = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=[];',./`~!@#$%^&*()_+{}|:\"<>?|\\";
        public int minCharCount = 2;
        public int maxCharCount = 4;
        private List<string> _sequence;
        public List<string> GetSequence()
        {
            _sequence = new List<string>();
            for (int i = minCharCount; i < (maxCharCount + 1); i++)
                RenderCombinations(i);
            return _sequence;
        }
        private void RenderCombinations(int charCount)
        {
            int _dictSize = characterDictionary.Length;
            int[] _containerMatrix = new int[charCount];
            char[] _splitDict = characterDictionary.ToCharArray();
            bool _maxReached = false;
            do
            {
                string _currentCombination = "";
                for (int i = 0; i < charCount; i++)
                    _currentCombination += _splitDict[_containerMatrix[i]];
                _sequence.Add(_currentCombination);
                // Let the shifting begin!
                bool _mustCarry = false;
                int _carryIndex = 0;
                do
                {
                    _mustCarry = false;
                    _containerMatrix[_carryIndex]++;
                    if (_containerMatrix[_carryIndex] == _dictSize)
                    {
                        _mustCarry = true;
                        _containerMatrix[_carryIndex] = 0;
                    }
                    _carryIndex++;
                    if (_carryIndex == charCount)
                    {
                        _mustCarry = false;
                        _maxReached = true;
                    }
                } while (_mustCarry);
            } while (!_maxReached);
        }
    }
