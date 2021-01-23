    Public bool AddRecipe(string TheUsersSpecifiedName)
    {
    bool noDuplicates = true;
    foreach (Recipe r in RecipeList)
    {
    if (r.Name == TheUserSpecifiedName)
    throw new ArgumentException();  //or whatever...
    noDuplicates = false;
    break;
    }
    if (noDuplicates)
    {
    Recipe theRecipe = new Recipe(TheUserSpecifiedName)
    RecipeList.Add(theRecipe);
    }
                
    return noDuplicates;
    }
