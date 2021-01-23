    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding SourceCollection}">
      <DataGrid.Columns>
         <DataGridTextColumn Binding="{Binding Index}"/>
         <DataGridTextColumn Binding="{Binding Colour}"/>
         <DataGridTextColumn Binding="{Binding Location}"/>
         <DataGridTextColumn Binding="{Binding Srno}"/>
      </DataGrid.Columns>
    </DataGrid>
