    <DataGrid Name="grdNewTickets" BorderThickness="1"  MouseLeftButtonDown="CellClicked" IsReadOnly="True">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Onderwerp" Width="Auto" 
                                Binding="{Binding Onderwerp}">       
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
