    protected void b_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        YourNewMethod(e.Property);
    }
    public void YourNewMethod(string propertyName)
    {
        switch(propertyName)
        {
           case "SearchResults":
              SearchResults = b.SearchResults;
              break;
        }   
    }
