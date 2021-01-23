    public ObservableCollection<MyFileInfo> FileInfos
    {
     get{return fileInfos;}
     set
     {
       if(fileInfos != value)
       {
         fileInfos = value;
         OnPropertyChanged("FileInfos");
       }
    }} 
