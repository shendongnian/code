    public string TermName{
        get{return NewTerm.Name;}
        set{NewTerm.Name = value;
            OnPropertyChanged("TermName");
        }//The same is applied for TermDescription
