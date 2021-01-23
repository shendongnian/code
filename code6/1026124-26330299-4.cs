    // a field 
    List<TextBox> ingredientTextBoxes = new List<TextBox>();
    private void Populate(int ingredientCount)
    {
        for (i = 1; i < ingredientCount; i++)
        {
            // Assign a consecutive name so can order by it
            TextBox tb = new TextBox { Name = "IngredientTextbox" + i};
            ingredientTextBoxes.Add(tb);
        }
    }
    // when you want the ingredients
    public List<string> GetIngredients
    {
        List<string> ingredients = new List<string>();
        foreach (var tb in ingredientTextBoxes)
        {
            ingredients.Add(tb.text);
        }
        return ingredients;
    }
    // contains
    private List<string> GetIngredientsMatching(string match)
    {
        // Contains really should take a StringComparison parameter, but it doesn't
        return ingredientTextBoxes
                        .Where(t => t.Text.ToUpper().Contains(match.ToUpper()))
                        .Select(t => t.Text);
    }
