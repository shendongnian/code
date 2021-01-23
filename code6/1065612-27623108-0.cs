    public static string[] Dictionary()
    {
        if (_dictionary == null)
        {
            _dictionary = _dictionaryRepository.LoadAllWords().ToArray();
        }
        return _dictionary;
    }
