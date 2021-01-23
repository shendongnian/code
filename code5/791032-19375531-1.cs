        <DataGrid ItemsSource="{Binding SomeCollection}">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding NonNumericProperty}"/>
                <local:DataGridNumericColumn Binding="{Binding NumericProperty}"/>
            </DataGrid.Columns>
        </DataGrid>
