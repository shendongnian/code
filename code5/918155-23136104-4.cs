    private void StackPanel_Initialized(object sender, EventArgs e)
    {
        StackPanel panel = (StackPanel)sender;
        ExclusionRadioConverter converter = (ExclusionRadioConverter)panel.FindResource("ExclusionRadio");
        converter.Host = panel.DataContext as OptionListMember;
    }
