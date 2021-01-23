    var list = new List<Model>
    {
        new Model {Value1 = 1, Description = "A"},
        new Model {Value1 = 1, Description = "B"}
    };
    Values = new ObservableCollection<Model>(list)
    {
         new ModelSummary(list) { Description = "Summary" }
    };
