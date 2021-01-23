    <DataGrid.Columns>
        <DataGridTextColumn Header="Sofware" Width="*" IsReadOnly="True" Binding="{Binding Path=Software}" />
        <DataGridComboBoxColumn>
            <DataGridComboBoxColumn.ElementStyle>
                <Style TargetType="{x:Type ComboBox}">
                    <Setter Property="ItemsSource" Value="{Binding Path=Versions}" />
                </Style>
            </DataGridComboBoxColumn.ElementStyle>
            <DataGridComboBoxColumn.EditingElementStyle>
                <Style TargetType="{x:Type ComboBox}">
                    <Setter Property="ItemsSource" Value="{Binding Path=Versions}" />
                </Style>
            </DataGridComboBoxColumn.EditingElementStyle>
        </DataGridComboBoxColumn>
    </DataGrid.Columns>
