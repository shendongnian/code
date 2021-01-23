    public Set LoadBaselineSet(ObservableCollection<Set> sets)
    {
        return LoadSet(sets, (x) => x.BaselineSetNumber)
    }
    
    public Set LoadComparisonSet(ObservableCollection<Set> sets)
    {
    	return LoadSet(sets, (x) => x.ComparisonSetNumber)
    }
    
    public Set LoadSet(ObservableCollection<Set> sets, Func<dbObject, Int> elementIdentity){
    	    using (var db = _contextFactory.GetContext())
        {
            var setNumber =
                db.Users.Where(x => x.Login == Environment.UserName)
                        .Select(elementIdentity).Single(); // !!! HERE
            return sets.Single(x => x.SetNumber == setNumber);
        }
    }
