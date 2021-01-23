    <DataGrid x:Name="myGrid" ItemsSource="{Binding Companies}">
         <DataGrid.Columns>
             <DataGridTextColumn Binding="{Binding CompanyName}"/>
         </DataGrid.Columns>
         <ie:Interaction.Triggers>
            <ie:EventTrigger EventName="SelectionChanged">
                <ie:InvokeCommandAction Command="{Binding SelectedItemChangedCommand}"  CommandParameter="{Binding ElementName=myGrid, Path=SelectedItem}"/>
            </ie:EventTrigger>
        </ie:Interaction.Triggers>
    </DataGrid>
    <ComboBox ItemsSource="{Binding SelectedCompanyPhoneNumbers}"/>
