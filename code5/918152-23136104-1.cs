    private void StackPanel_Loaded(object sender, RoutedEventArgs e)
    {
        StackPanel panel = (StackPanel)sender;
        ExclusionRadioConverter converter = (ExclusionRadioConverter)panel.FindResource("ExclusionRadio");
        converter.Host = panel.DataContext as OptionListMember;
    }
