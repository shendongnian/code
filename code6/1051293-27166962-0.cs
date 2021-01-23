    for (int i = 0; i < 4; i++)
    {
        OnlineMarketerMixColumns.Add(
            new DataGridTextColumn
            {
                Header = string.Format("ColumnNumber"+i),
                Binding = new Binding(string.Format("[{0}]", i))
                {
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                },
            });
    }
