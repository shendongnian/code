    public class ViewModel
    {
       /// <summary>
        /// Gets or sets a value indicating whether the search resulted in data
        /// </summary>
        public bool? HasResult
        {
            get
            {
                return this.hasResult;
            }
            set
            {
                this.hasResult = value;
                this.RaisePropertyChanged("HasResult");
            }
        }
       /// <summary>
        /// Gets or sets a value indicating a search result message
        /// </summary>
        public bool? SearchResultMessage
        {
            get
            {
                return this.searchResultMessage;
            }
            set
            {
                this.hasResult = value;
                this.RaisePropertyChanged("SearchResultMessage");
            }
        }
    
      //Your command or action that searches for results
      public void Search()
      {
        //Does what it used to do
        
        //Check if there is result
        if(results.Count == 0)
        {
           this.HasResult = false;
           this.SearchResultMessage = "Nothing is loaded";
        }
      }
    }
