    Form.Controls
        .OfType<TextBox>()
        .AsQueryable()
        .Where(x => x.ID != "TextBox1")
        .ToList()
        .ForEach(y =>
    {
        y.Visible = false;
    });
