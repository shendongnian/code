    <DataGrid ItemsSource="{Binding yourCollection}" AutoGenerateColumns="False" >
        <DataGrid.Columns>
            <DataGridTextColumn Header="First Name"  Binding="{Binding FirstName}"/>
            <DataGridTextColumn Header="Last Name" Binding="{Binding LastName}" />
            <DataGridHyperlinkColumn Header="Email" Binding="{Binding Email}"  
                ContentBinding="{Binding Email, Converter={StaticResource 
                EmailConverter}}" />
            <DataGridCheckBoxColumn Header="Member?" Binding="{Binding IsMember}" />
            <DataGridComboBoxColumn Header="Order Status"  SelectedItemBinding="{Binding 
                 Status}" ItemsSource="{Binding Source={StaticResource myEnum}}" />
        </DataGrid.Columns>
    </DataGrid>
