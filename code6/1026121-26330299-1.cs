    // a field 
    List<TextBox> textBoxes = new List<TextBox>();
    // the populate method
    int i = Form1.ingredientCount;
    for (i = 1; i < Form1.ingredientCount; i++)
    {
        TextBox tb = new TextBox { Name = "TB" + i};
        textBoxes.Add(tb);
    }
    // when you want the ingredients
    List<string> ingredients = new List<string>();
    foreach (var tb in textBoxes)
    {
         ingredients.Add(tb.text);
    }
    // contains
    private List<string> GetMatches(string match)
    {
        // Contains really should take a StringComparison parameter, but it doesn't
        return textBoxes.Where(t => t.Text.ToUpper().Contains(match.ToUpper()))
                        .Select(t => y.Text);
    }
