    public Form1()
    {
        InitializeComponent();
        FullAutoCompleteSelection.Add("Item1");
        FullAutoCompleteSelection.Add("Item2");
        FullAutoCompleteSelection.Add("Item3");
        FullAutoCompleteSelection.Add("Item4");
        FullAutoCompleteSelection.Add("Item5");
        FullAutoCompleteSelection.Add("Item6");
        FullAutoCompleteSelection.Add("Item7");
        FullAutoCompleteSelection.Add("Item8");
        FullAutoCompleteSelection.Add("Item9");
        autoCompleteTestBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        autoCompleteTestBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        UpdateAutoCompleteSource();
    }
