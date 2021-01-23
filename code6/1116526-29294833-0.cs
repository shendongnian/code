    <DataGrid ItemsSource="{Binding Items}" x:Name="ItemsDataGrid" Margin="0,30,0,0"
             AutoGenerateColumns="False">
       <DataGrid.Columns>
         <DataGridTextColumn Binding="{Binding SlNo, Mode=OneWay}" Header="Sl. No." MinWidth="125" />
         <DataGridTextColumn Binding="{Binding ItemName}" Header="Name" MinWidth="200" />
         <DataGridTextColumn Binding="{Binding Quantity} Header="Total Quantity" MinWidth="200" />
         <DataGridTextColumn Binding="{Binding Remaining} Header="Remaining" MinWidth="200" />
         <DataGridTextColumn Binding="{Binding Cost} Header="Cost/Each" MinWidth="200" />
       </DataGrid.Columns>
      </DataGrid>
