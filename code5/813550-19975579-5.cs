    // List of potential Items, used to populate the options for the Subitems combo box
    public ObservableCollection<string> PossibleSubitems
    {
      get
      {
        ObservableCollection<string> retVal = new ObservableCollection<string>();
        if (CurrentItem == PossibleItems[0])
        {
          retVal.Add("Subitem A");
          retVal.Add("Subitem B");
        }
        else
        {
          retVal.Add("Subitem B");
          retVal.Add("Subitem C");
        }
        CoerceSubitem();
        return retVal;
      }
    }
