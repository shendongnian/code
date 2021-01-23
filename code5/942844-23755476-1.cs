     private ObservableCollection<Details> _CollectionofDetails=new ObservableCollection<Details>();
        public ObservableCollection<Details> CollectionofDetails
        {
            get { return _CollectionofDetails; }
            set { _CollectionofDetails = value; RaisePropertyChanged("CollectionofDetails"); }
        }
     private RelayCommand _MyCommand;
        public RelayCommand MyCommand
        {
            get { return _MyCommand??(_MyCommand=new RelayCommand(Methodcall)); }
            set { _MyCommand = value; }
        }
      void Methodcall()
        {
            
            foreach (string Datei in Directory.GetFiles(@"C:\textfile", "*.txt"))
            {
                StreamReader reader = new StreamReader(Datei);
                
              
                int i=0;
                string line = reader.ReadToEnd().Replace("\n","");
                string[] t = line.Split('\r');
                Details d = new Details();
                d.CorporationName = t[i];
                d.Prefix = t[i + 1];
                d.FirstName = t[i + 2];
                d.LastName = t[i + 3];
                CollectionofDetails.Add(d);
                reader.Close();
               
                
               
            }
        }
    public class Details
    {
        public string CorporationName { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
