    public string Naam
            {
                get { return thename; }
                set
                {
                    if (value.Length >= 3 && value.Length <= 10)
                        thename = value;
                    else
                        throw new ArgumentOutOfRangeException();
                } 
            }
