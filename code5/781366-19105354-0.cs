    <DataGrid>
      <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding Id }"/>
        <DataGridTextColumn Binding="{Binding Name}"/>
        <DataGridTextColumn Binding="{Binding HomeAddr, Converter={StaticResource AddressToStringConverter}}"/>
      </DataGrid.Columns>
    </DataGrid>
