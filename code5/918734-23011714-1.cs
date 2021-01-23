    private string _entier = "30";
    public string Entier
        {
            get { return _entier; }
            set
            {
                if (!Regex.IsMatch(Entier.Trim(), NumberPattern, RegexOptions.IgnoreCase))
                    throw new ArgumentException("can only have numbers not characters");
                _entier = value;
                OnPropertyChanged("Entier");
            }
        }
