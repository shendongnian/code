    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding UserDataObject}">
      <DataGrid.Columns>
        <DataGridTextColumn Header="ID" Binding="{Binding ID}"/>
        <DataGridTextColumn Header="Username" Binding="{Binding Username}"/>
        <DataGridComboBoxColumn Header="Role" ItemsSource="{Binding Role}"/>
      </DataGrid.Columns>
    </DataGrid>
