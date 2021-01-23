    private void tblkpersonname_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("Suggestion chosen : {0}", ((values)args.SelectedItem).Name);
        getitemselected(args.SelectedItem as values);
    }
    public void getitemselected(values selectedItem)
    {
        if ((selectedItem) != null)
        {
            //Some Statements
        }
    }
