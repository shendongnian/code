    private int _myInt;
    public int MyInt {
        get { return this._name; }
        set { 
            if (this._name == 1) {
                this._name = value;
            } else {
                    this._name = 0;
            }
        }
    }
