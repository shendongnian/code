    public string Naam
            {
                get { return thename; }
                set
                {
                    if (value.ToCharArray().Length >= 3 && value.ToCharArray().Length <= 10)
                        thename = value;
                    else
                        throw new ArgumentOutOfRangeException();
                } 
            }
