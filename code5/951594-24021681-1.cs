    DropDownList2.Items.Clear();
    string[] itens = new string[4] {
        "-- Year --",
        DateTime.Today.Year.ToString(),
        DateTime.Today.AddYears(-1).Year.ToString(),
        DateTime.Today.AddYears(-2).Year.ToString()
    };
    DropDownList2.Items.AddRange(itens);
