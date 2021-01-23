        <DataGrid x:Name="dG">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="auto" />
                                </Grid.ColumnDefinitions>
                                <TextBox x:Name="tbx">test</TextBox>
                                <Button Content="click me" Grid.Column="1" Click="OnClick" />
                            </Grid>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
            <DataGrid.ItemsSource>
                test
            </DataGrid.ItemsSource>
        </DataGrid>
