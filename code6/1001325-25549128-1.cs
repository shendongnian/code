    <wpf_toolkit:DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Items, Mode=TwoWay}"
                              RowStyle="{StaticResource DataGridRowMaxHeihgt }" ColumnWidth="*"
                              IsReadOnly="True">
          
            <wpf_toolkit:DataGrid.Columns>
                <wpf_toolkit:DataGridTextColumn Header="Some long text 2" IsReadOnly="True"
                                                Binding="{Binding SomeLongText1, Mode=TwoWay}"
                                                CellStyle="{StaticResource DataGridTextColumnWithScrollBar}"/>
                <wpf_toolkit:DataGridTextColumn Header="Some long text 2" 
                                                Binding="{Binding SomeLongText2, Mode=TwoWay}" IsReadOnly="False"
                                                CellStyle="{StaticResource DataGridTextColumnWithScrollBar}"/>
            </wpf_toolkit:DataGrid.Columns>
        </wpf_toolkit:DataGrid>
