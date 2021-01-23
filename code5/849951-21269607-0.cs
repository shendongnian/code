    <sdk:DataGrid Grid.Row="2" ItemsSource="{Binding Data}">
       <sdk:DataGrid.Columns>
           <sdk:DataGridTextColumn Binding="{Binding Key}"></sdk:DataGridTextColumn>
           <sdk:DataGridTextColumn Binding="{Binding Value}"></sdk:DataGridTextColumn>
        </sdk:DataGrid.Columns>
    </sdk:DataGrid>
