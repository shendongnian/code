    public void SetState(int stateNum)
    {
        _state = stateNum;
    }
    private int _state = 1;
    public bool IsThisStateOne { get { return _state == 1; } }
    public bool IsThisStateTwo { get { return _state == 2; } }
    public bool IsThisStateThree { get { return _state == 3; } }
