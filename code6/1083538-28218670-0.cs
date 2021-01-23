    for (var j = 3; j <= excelSheet.Dimension.End.Row; ++j)
    {
        var name = (excelSheet.Cells[j, 0].Value ?? "").ToString();
        var number = (excelSheet.Cells[j, 1].Value ?? "").ToString();
        var newThings = new Store
        {
            Name = name,
            Number = number
        };
    }
