    private char? classLetter = null; // make it nullable
    public char ClassLetter
    {
        get {
            if(classLetter == null) { // if we don't have a value yet
                // do something, like throwing an exception
            }else{ // if we do have a value already
                return classLetter.Value; // here we return char, not char?
            }
        }
        set 
        {
            if (classLetter == null) {
                classLetter = value;
                RaisePropertyChanged("ClassLetter");
            }
            else throw new ArgumentOutOfRangeException();
        }
    }
