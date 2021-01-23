    protected void b_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        YourNewMethod(e.Property);
    }
    protected void YourNewMethod(string propertyName)
    {
        switch(propertyName)
        {
           case "SearchResults":
              SearchResults = b.SearchResults;
              break;
        }   
    }
