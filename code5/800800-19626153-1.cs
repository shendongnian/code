    public class loggedin:INotitfyPropertyChanged
    {
        private static loggedin instance=new loggedin ();
        public static loggedin Instance
        {
             get{return instance;}
        }
        private string alisa;
        public string aliasname 
        { 
          get
          {
              return alisa;
          } 
          set
          {
              alisa=value;
              RaisePropertyChanged("aliasname");
               
          } 
        }
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) 
            { 
              PropertyChanged(this, new PropertyChangedEventArgs(prop)); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
