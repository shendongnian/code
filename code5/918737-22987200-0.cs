    <DataGrid ItemsSource="{Binding Orders}" AutoGenerateColumns="False">
      <DataGrid.Columns> <-- This is missing.
         <DataGridTextColumn Header="Product Name" Binding="{Binding ProductName}" />
         <DataGridTextColumn Header="Quantity" Binding="{Binding Quantity}" />
         <DataGridTextColumn Header="Unit Price" Binding="{Binding UnitPrice}" />
         <DataGridTextColumn Header="Total Price" Binding="{Binding TotalPrice}" />
      </DataGrid.Columns>
    </DataGrid>
