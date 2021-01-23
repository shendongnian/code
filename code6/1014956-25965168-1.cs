                            <DataGridTextColumn Binding="{Binding BackR, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                                        Header="R" Width="40"/>
                            <DataGridTextColumn Binding="{Binding BackG, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                                        Header="G" Width="40"/>
                            <DataGridTextColumn Binding="{Binding BackB, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                                        Header="B" Width="40"/>
                            <DataGridTextColumn Binding="{Binding Tags, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                                        Header="Tags" Width="90"/>
                        </DataGrid.Columns>
                    </DataGrid>
