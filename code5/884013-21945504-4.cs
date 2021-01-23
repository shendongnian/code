    <ComboBox x:Name="cmbDDV" 
        ItemsSource="{Binding Path=DDV_Data}"
        SelectedItem="{Binding Path=SelectedItem}"
        IsSynchronizedWithCurrentItem="True"
        Width="50" />
    ...
    private DDV_Class _SelectedItem;
    public DDV_Class SelectedItem
    {
        get { return _SelectedItem; }
        set { _SelectedItem = value; }
    }
    private ObservableCollection<DDV_Class> _DDV_Data = new ObservableCollection<DDV_Class>();
    public ObservableCollection<DDV_Class> DDV_Data
    {
        get { return _DDV_Data; }
        set { _DDV_Data = value; }
    }
