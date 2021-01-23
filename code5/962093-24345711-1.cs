    <DataGrid Name="data1" AutoGenerateColumns="False"
              ItemsSource="{Binding MyDataTable}">
       <DataGrid.Columns>
          ..... // Other columns will go here.
         <DataGridTextColumn Binding="{Binding Node.Name}"/>
       </DataGrid.Columns>
    </DataGrid>
