    private static List<Widget> widgets;  
    static readonly object _widgetsLock = new object();
    
    public async Task<List<SearchResult>> Search(string term)
    {
        if(widgets == null) {
            // This call takes up to 60 seconds
            lock(_widgetsLock)
                 if(widgets == null)
                      widgets = await GetWidgets();
        }
        return SearchUtil.Search(term, widgets);
    }
