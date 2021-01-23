    public MainWindow()
    {
        InitializeComponent();
    
        txtAutoProductCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtAutoProductCode.AutoCompleteCustomSource.Add("item1");
        txtAutoProductCode.AutoCompleteCustomSource.Add("item2");
    }
    <Grid>
        <WindowsFormsHost Margin="272,10,396,42" Width="240">
            <wf:TextBox x:Name="txtAutoProductCode" AutoCompleteMode="SuggestAppend"/>
        </WindowsFormsHost>
    </Grid>
