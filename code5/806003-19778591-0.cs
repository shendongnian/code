    <Grid>
        <DataGrid CanUserAddRows="True"  AutoGenerateColumns="False"  ItemsSource="{Binding Pricelist}" >
            <DataGrid.Columns>
                <DataGridTextColumn Header="Price" Width="60" Binding="{Binding Price, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, ValidatesOnDataErrors=True}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
