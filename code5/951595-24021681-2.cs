    DropDownList2.Items.Clear();
    ListItem[] itens = new ListItem[4] {
        new ListItem("-- Year --"),
        new ListItem(DateTime.Today.Year.ToString()),
        new ListItem(DateTime.Today.AddYears(-1).Year.ToString()),
        new ListItem(DateTime.Today.AddYears(-2).Year.ToString())
    };
    DropDownList2.Items.AddRange(itens);
