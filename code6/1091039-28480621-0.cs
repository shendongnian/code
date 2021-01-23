    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <ComboBox Grid.Row="0" ItemsSource="{Binding Path=Lots}">
            <ComboBox.ItemsPanel>
                <ItemsPanelTemplate>
                    <VirtualizingStackPanel />
                </ItemsPanelTemplate>
            </ComboBox.ItemsPanel>
        </ComboBox> 
        <ListBox  Grid.Row="1" ItemsSource="{Binding Path=Lots}" 
                    VirtualizingStackPanel.IsVirtualizing="True"/>
    </Grid>
    
    private List<string> lots;
    public  List<string> Lots
    {
        get
        {
            if (lots == null)
            {
                lots = new List<string>();
                for (int i = 0; i < 1000000; i++) lots.Add("lot " + i.ToString());
            }
            return lots;
        }
    }
