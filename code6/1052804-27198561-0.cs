    if (e.PropertyType == typeof(System.DateTime))
    {
        Style styleCenter = new Style(typeof(DataGridCell));
    
        styleCenter.Setters.Add(new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Center));
        styleCenter.Setters.Add(new Setter(FontWeightProperty, FontWeights.Bold));
        styleCenter.Setters.Add(new Setter(ForegroundProperty, Brushes.Red));
    
        (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        (e.Column as DataGridTextColumn).CellStyle = styleCenter;
    }
