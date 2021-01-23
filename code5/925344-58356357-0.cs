    private List<v_Repairs> searchRepairs = new List<v_Repairs>();
    int searchCount = 0;
    int searchPosition = 0; 
    private string searchText;
            public string SearchText
            {
                get { return searchText; }
                set
                {
                    searchText = value;
                    RaisedPropertyChanged("SearchText");
                }
            }
     private ICommand searchCommand;
            public ICommand SearchCommand
            {
                get
                {
                    if (searchCommand == null)
                    {
                        searchCommand = new RelayCommand(new Action<object>(Search));
                    }
                    return searchCommand;
                }
                set
                {
                    searchCommand = value;
                    RaisedPropertyChanged("SearchCommand");
                }
            }
            public void Search(object Parameter)
            {
                if (!String.IsNullOrWhiteSpace(SearchText))
                {
                    searchPosition = 0;
                    searchRepairs = V_Repairs.Where(r => r.Serial_Number.Contains(SearchText)).ToList();
                    searchCount = searchRepairs.Count;
                    SelectedItem = (v_Repairs)searchRepairs[0];
                    searchPosition++;
                }
            }
     private ICommand searchNextCommand;
            public ICommand SearchNextCommand
            {
                get
                {
                    if (searchNextCommand == null)
                    {
                        searchNextCommand = new RelayCommand(new Action<object>(SearchNext));
                    }
                    return searchNextCommand;
                }
                set
                {
                    searchNextCommand = value;
                    RaisedPropertyChanged("SearchNextCommand");
                }
            }
            public void SearchNext(object Parameter)
            {
                if (searchRepairs.Count > 0)
                {
                    if (searchRepairs[0].Serial_Number.Contains(SearchText))
                    {
                        if (searchPosition < searchRepairs.Count)
                        {
                            SelectedItem = (v_Repairs)searchRepairs[searchPosition];
                            searchPosition++;
                        }
                        else if (searchPosition == searchRepairs.Count)
                        {
                            SelectedItem = (v_Repairs)searchRepairs[0];
                            searchPosition = 1;
                        }
                        else
                        {
                            searchPosition = 0;
                            searchCount = 0;
                            searchRepairs.Clear();
                        }
                    }
                }
            }
