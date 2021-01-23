      <Grid>
        <DataGrid ItemsSource="{Binding A}"  AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Choose" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding ListOfValues}" SelectedValue="{Binding Selected, UpdateSourceTrigger=PropertyChanged}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Value">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                          
                            <TextBox Text="{Binding Selected, UpdateSourceTrigger=PropertyChanged}" IsReadOnly="{Binding ValueAvalible}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid
