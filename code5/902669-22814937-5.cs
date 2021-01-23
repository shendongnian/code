    private static IList<string> Ingredients { get; set; }
    private static IList<string> Additives { get; set; }
    private static IList<Func<string, string, bool>> Rules { get; set; }
    
    private static void Main(string[] args)
    {
        Ingredients = new List<string>() { "Apple", "Orange", "Peach" };
        Additives = new List<string>() { "Vodka", "Rum", "Whiskey" };
        Rules = new List<Func<string, string, bool>>() { (ingredient1, ingredient2) => { return (ingredient1 != "Peach" && ingredient2 != "Whiskey"); } };
        var additivesOrganisationMatchingAllTheRules = FindMatch();
    }
    
    private static IList<string> FindMatch()
    {
        // here we should enumerate all sets and then enumerate permutation of all the sets
        // instead for the example we just enumerate the permutations
        foreach (var additivesPermutation in Additives.GetCombinations())
        {
            for (int i = 0; i < additivesPermutation.Count; i++)
            {
                var thisSituationIsOk = Rules.All(r => r(Ingredients[i], Additives[i]));
                if (thisSituationIsOk) return additivesPermutation;
            }
        }
        return null;
    }
