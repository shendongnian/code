    <DataGridTemplateColumn>
        <DataGridTemplateColumn.Header>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Column="1" Text="Value1" IsEnabled="{Binding ElementName=chkValue1, Path=IsChecked}" />
                <CheckBox Name="chkValue1" Grid.Column="0" Width="16" />
            </Grid>
        </DataGridTemplateColumn.Header>
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Path=myProperty}" />
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
            <DataGridTemplateColumn.CellEditingTemplate>
                <DataTemplate>
                    <TextBox IsEnabled="{Binding ElementName=chkValue1, Path=IsChecked}" Text="{Binding Path=myProperty, Mode=TwoWay}" />
                </DataTemplate>
        </DataGridTemplateColumn.CellEditingTemplate>
    </DataGridTemplateColumn>
