    private static IList<string> Ingredients { get; set; }
    private static IList<string> Additives { get; set; }
    private static IList<Func<string, IList<string>, bool>> Rules { get; set; }
    
    private static void Main(string[] args)
    {
        Ingredients = new List<string>() { "Apple", "Orange", "Peach" };
        Additives = new List<string>() { "Vodka", "Rum", "Whiskey" };
        Additives.Add("Separator");
        Additives.Add("Separator"); // add as many separators as the number of ingredients - 1
        Rules = new List<Func<string, IList<string>, bool>>() {
            (ingredient1, ingredient2) => { return (ingredient1 != "Peach" && ingredient2.All(s => s != "Whiskey")); }
            , 
            (ingredient1, ingredient2) => { return ingredient2.Count > 0; }
        };
        var additivesOrganisationMatchingAllTheRules = FindMatch();
    }
    
    private static IList<IList<string>> FindMatch()
    {
        // separators will create the subsets
        foreach (var additivesPermutation in Additives.GetCombinations())
        {
            var Sets = Split(additivesPermutation);
    
            for (int i = 0; i < Sets.Count ; i++)
            {
                var thisSituationIsOk = Rules.All(r => r(Ingredients[i], Sets[i]));
                if (thisSituationIsOk) return Sets;
            }
        }
        return null;
    }
    
    private static IList<IList<string>> Split(IList<string> values)
    {
        var splitValues = new List<IList<String>>();
        var currentList = new List<string>();
        foreach (var value in values)
        {
            if (value == "Separator")
            {
                splitValues.Add(currentList);
                currentList = new List<string>();
            }
            else
            {
                currentList.Add(value);
            }
        }
        splitValues.Add(currentList);
        return splitValues;
    }
