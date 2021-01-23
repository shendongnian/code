        <DataGrid ItemsSource="{Binding ElementName=fRoot, Path=Items}" Name="dgTU" Grid.Row="1" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Ilosc, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Binding="{Binding Cena, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Binding="{Binding Vat, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Binding="{Binding CenaBrutto}"/>
            </DataGrid.Columns>
        </DataGrid>
