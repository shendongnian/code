    private char? classLetter;
    public char ClassLetter
    {
        get { return classLetter.Value; // this will throw exception, if value hasn't set }
        set 
        {
            if (classLetter != null)
            {
                throw new InvalidOperationException("ClassLetter has been set already.");
            }
 
            classLetter = value;
            RaisePropertyChanged("ClassLetter");
        }
    }
