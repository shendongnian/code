    Items.Add(new listViewItem
        (
            modname.ModName.ToString(),
            Path.Combine(dir, modname.ModLink),
            new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green)
        )
    );
