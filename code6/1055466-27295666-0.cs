    public class SomeClass : INotifyPropertyChanged
    {
        /* other code here */
    
        public string NumeroParada
        {
             get { return numeroParada; }
             set
             {
                 if (numeroParada != value)
                 {
                      numeroParada = value;
                      OnPropertyChanged("NumeroParada");
                 }
             }
        }
        private string numeroParada;    
    }
