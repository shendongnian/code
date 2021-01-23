    public class Doc1ViewModel : ViewModelBase {
        private string path;
	    public string Path
	    {
		    get { return path;}
		    set { 
                if(path!=value) {
                    path = value;
                    OnPropertyChanged("Path");
                }
            }
	}
    }
