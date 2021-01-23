    <DataGrid AutoGenerateColumns="False" x:Name="DataGrid_Test">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Name"  >
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Text="{Binding Path=Name}"  VerticalAlignment="Center" Margin="3,3,3,3"/>
                                </Grid>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                    <DataGridTemplateColumn Header="Childrens">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <DataGrid AutoGenerateColumns="False" CanUserAddRows="False" ItemsSource="{Binding Children}">
                                    <DataGrid.Columns>
                                        <DataGridTextColumn Header="Block Name" Binding="{Binding BlockName}" />
                                        <DataGridTextColumn Header="Block Number" Binding="{Binding BlockNumber}" />
                                        <DataGridTextColumn Header="Block Adress" Binding="{Binding BlockAdress}" />
                                        <DataGridTextColumn Header="BlockStatus" Binding="{Binding BlockStatus}" />
                                    </DataGrid.Columns>
                                </DataGrid>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
