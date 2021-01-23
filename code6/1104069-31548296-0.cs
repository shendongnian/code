        <DataGrid>
            <DataGrid.Columns>
                <DataGridTextColumn>
                    <!-- Column Width--!>
                        <DataGridTextColumn.Width>4</DataGridTextColumn.Width> 
                    <!-- Column Width--!>
                    
                    <DataGridTextColumn.IsReadOnly>False</DataGridTextColumn.IsReadOnly>
                   
                    <DataGridTextColumn.Binding>
                       <Binding Path="{Binding Description, Mode=TwoWay}"/>
                    </DataGridTextColumn.Binding>
    
                    <DataGridTextColumn.Header>
                        <DataGridColumnHeader Content="{x:Static p:Resources.DG_HEADER_DESC}" 
                                              HorizontalAlignment="Stretch" 
                                              HorizontalContentAlignment="Center" 
                                              TextBlock.TextAlignment="Center"> 
                            <!-- Header Width--!>
                                <DataGridColumnHeader.Width>4</DataGridColumnHeader.Width>
                           <!-- Header Width--!>
                        </DataGridColumnHeader> 
                    </DataGridTextColumn.Header>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
