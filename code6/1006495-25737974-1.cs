    // Class to Store your String Exceptions
    public class Errors
    {
       // String Exception Error 
        public string ErrorText { get; set; }
        public Errors(string error)
        {
            this.ErrorText = error;
        }
    }
      // Code to Add exception error to ListBox Itemssource. Before this create List that having Error like this.
        List<Errors> ErrorsSource = new List<Errors>();
       ErrorsSource.Add(new Errors("Error	1	Value of type 'System.IO.FileAccess' cannot be 
    converted to 'System.IO.IsolatedStorage.IsolatedStorageFile'"));
    
        ErrorsSource.Add(new Errors( "The exception (Operation not permitted on 
    IsolatedStorageFileStream.) occurs at _Play function while reading the file "));
    
        List.ItemsSource = ErrorsSource;
