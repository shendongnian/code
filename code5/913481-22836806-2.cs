    public List<UITextField> YourTextFields = new List<UITextField>();
    public YouTableViewSourceConstructor()
    {
        foreach(var elementItem in elements.Where(e => e.Type == "textField").ToList())
        {
            YourTextFields.Add(new UITextField(){Tag = 99});
        }
    }
