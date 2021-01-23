    <DataGrid AutoGenerateColumns="False" Name="myGridTest">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Text" Binding="{Binding MyText}" />
            <DataGridTemplateColumn Header="Combobox">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox SelectedIndex="0" ItemsSource="{Binding ComboList}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
