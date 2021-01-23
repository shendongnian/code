    public List<strings> TrueLines
    {
       get { return LinesCollection.Where(ln => ln.ShowContent == true).ToList() }
    }
    
    
    public List<Model> LinesCollection
    {
       get { ... }
       set {  OnPropertyChanged("LinesCollection"); 
              OnPropertyChanged("TrueLines");
    }
