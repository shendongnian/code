    /* Generated Code from an ORM */
    public IMyCreation CreateTestObject(bool isBig, bool isColoured)
    {
        IMyCreation _myCreation = new MyCreation();
        _myCreation.IsBig = isBig;
        _myCreation.IsColoured = isColoured;
        return _myCreation;
    }
    
