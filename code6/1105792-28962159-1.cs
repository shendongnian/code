    public int this[PropertyName index]
    {
        get
        {
            switch (index)
            {
                case PropertyName.A: return A;
                case PropertyName.B: return B;
                case PropertyName.C: return C;
                default: throw new ArgumentException();
            }
        }
        set
        {
            switch (index)
            {
                case PropertyName.A: A = value; break;
                case PropertyName.B: B = value; break;
                case PropertyName.C: C = value; break;
                default: throw new ArgumentException();
            }
            OnPropertyChanged("Item");
        }
    }
