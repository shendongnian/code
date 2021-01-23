    // a field 
    List<TextBox> ingredientTextBoxes = new List<TextBox>();
    // the populate method
    int i = Form1.ingredientCount;
    for (i = 1; i < Form1.ingredientCount; i++)
    {
        TextBox tb = new TextBox { Name = "IngredientTextbox" + i};
        ingredientTextBoxes.Add(tb);
    }
    // when you want the ingredients
    List<string> ingredients = new List<string>();
    foreach (var tb in ingredientTextBoxes)
    {
         ingredients.Add(tb.text);
    }
    // contains
    private List<string> GetMatches(string match)
    {
        // Contains really should take a StringComparison parameter, but it doesn't
        return ingredientTextBoxes
                        .Where(t => t.Text.ToUpper().Contains(match.ToUpper()))
                        .Select(t => t.Text);
    }
