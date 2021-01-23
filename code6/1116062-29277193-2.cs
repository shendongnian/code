    Form.Controls
        .OfType<TextBox>()
        .Where(x => x.ID != "TextBox1")
        .ToList()
        .ForEach(y =>
    {
        y.Visible = false;
    });
