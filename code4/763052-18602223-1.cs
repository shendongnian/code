    public string FileName {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }
     public string Path { get;  set; }
     public string Extension { get;  set; }
