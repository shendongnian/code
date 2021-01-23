     <DataGrid Name="grdSignals" Grid.Column="1" ItemsSource="{Binding}"  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Signal Name" Binding="{Binding SignalName, Mode=TwoWay}"/>
                <DataGridTextColumn Header="Value" Binding="{Binding SignalValue, Mode=TwoWay}" />
            </DataGrid.Columns>
        </DataGrid>
