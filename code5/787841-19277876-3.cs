    <DataGrid Name="poolDataGrid" AutoGenerateColumns="False" >
       <DataGrid.Columns>
          <DataGridTextColumn Header="Column1"  Binding="{Binding ProjectedPointsAvg }"/>
          <DataGridTextColumn Header="Column2" Binding="{Binding ProjectedPointsHi }" />
          <DataGridTextColumn Header="Column3" Binding="{Binding ProjectedPointsLo}" />
       </DataGrid.Columns>
    </DataGrid>
