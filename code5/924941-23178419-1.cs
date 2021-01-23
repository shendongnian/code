      <DataGrid AutoGenerateColumns="False" Name="myGrid" Margin="10">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Path=Name}"></DataGridTextColumn>                
                <DataGridComboBoxColumn Width="100" x:Name="Result" SelectedValueBinding="{Binding Result, Mode=TwoWay}" DisplayMemberPath="{Binding Result}"></DataGridComboBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
