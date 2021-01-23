    public void Test()
    {
        var tcollection = new List<ProfitItemViewModel>();
        Action tloadAction = ()=> 
        {
            foreach (Item item in Item.Search(_SearchText, _SearchLevelMin, _SearchLevelMax, _SearchRarity, _SearchType,_SearchRemoveUnavailable))
            {                
                tcollection.Add(new ProfitItemViewModel(new ProfitItem(item))));
            }
        };
        Action tupdateGridAction = ()=> 
        {
            foreach (Item item in tcollection)
            {                
                ItemCollection.Add(item);
            }
        };
        LockAndDoInBackground(tloadAction, "Generating Information...", null,  tupdateGridAction);
    }
