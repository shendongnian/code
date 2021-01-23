    private sealed class EnumeratorWithSomeWeirdName : IEnumerator<string>, IEnumerable<string>
    {
    private string _current;
    private int _state = 0;
    private List<string> list_;
    private List<string>.Enumerator _wrap;
    public string Current
    {
        get { return _current; }
    }
    object IEnumerator.Current
    {
        get { return _current; }
    }
    public bool MoveNext()
    {
        switch (_state) {
            case 0:
                _state = -1;
                list_ = new List<string>();
                list_.Add("1");
                list_.Add("2");
                list_.Add("3");
                list_.Add("4");
                list_.Add("5");
                _wrap = list_.GetEnumerator();
                _state = 1;
                break;
            case 1:
                return false;
            case 2:
                _state = 1;
                break;
            default:
                return false;
        }
        if (_wrap.MoveNext()) {
            _current = _wrap.Current;
            _state = 2;
            return true;
        }
        _state = -1;
        return false;
    }
    IEnumerator<string> GetEnumerator()
    {
        return new EnumeratorWithSomeWeirdName();
    }
    IEnumerator IEnumerator.GetEnumerator()
    {
        return new EnumeratorWithSomeWeirdName();
    }
    void IDisposable.Dispose()
    {
        _wrap.Dispose();
    }
    void IEnumerator.Reset()
    {
        throw new NotSupportedException();
    }
    }
