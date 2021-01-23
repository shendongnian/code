    for (int i = 0; i < Model.First().Data.Count; i++)
    {
        int local = i;
        cols.Add(grid.Column(Model.First().Data[i].Name, Model.First().Data[i].Label, 
            format: item => Html.Raw("<text>" + item.Data[local].Value + "</text>")
        ));
    }
