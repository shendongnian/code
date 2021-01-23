    <DataGrid ItemsSource="{Binding Companies}">
         <DataGrid.Columns>
             <DataGridComboBoxColumn ItemsSource="{Binding CompanyPhoneNumbers}"/>
             <DataGridTextColumn Binding="{Binding CompanyName}"/>
         </DataGrid.Columns>
    </DataGrid>
