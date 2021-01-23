    <DataGrid Name="poolDataGrid" AutoGenerateColumns="False" >
       <DataGrid.Columns>
          <DataGridTextColumn Header="Coulumn1"  Binding="{Binding ProjectedPointsAvg }"/>
          <DataGridTextColumn Header="Coulumn2" Binding="{Binding ProjectedPointsHi }" />
          <DataGridTextColumn Header="Coulumn3" Binding="{Binding ProjectedPointsLo}" />
       </DataGrid.Columns>
    </DataGrid>
