    <DataGrid x:Name="DataGrid" RowEditEnding="DataGrid_OnRowEditEnding"  AutoGenerateColumns="False" Margin="5">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Header="Age" Binding="{Binding Age, UpdateSourceTrigger=PropertyChanged}"/>
            </DataGrid.Columns>
            
        </DataGrid>
