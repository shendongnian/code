     public float ProcessTime
     {
        get {return _processTime;}
     }
     //after you do your COM stuff call
     this.OnPropertyChanged("ProcessTime"); 
 
