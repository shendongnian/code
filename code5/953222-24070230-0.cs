        <DataGrid ItemsSource="{Binding Samples}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}"/>
                <DataGridTextColumn Binding="{Binding ExperimentResult.MeasuredValue}"/>
            </DataGrid.Columns>
        </DataGrid>
