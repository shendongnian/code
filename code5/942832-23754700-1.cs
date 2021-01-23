      <DataGrid AutoGenerateColumns="False" IsReadOnly="True" SelectionMode="Single" GridLinesVisibility="None">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Border  BorderBrush="Black" >
                                <Border.Style>
                                    <Style TargetType="Border">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource FindAncestor, AncestorType=DataGridCell}}" Value="True">
                                                <Setter Property="BorderThickness" Value="1"></Setter>
                                            </DataTrigger>
                                        </Style.Triggers>
                                            
                                    </Style>
                                </Border.Style>
                                <Grid></Grid>
                            </Border>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
             </DataGrid.Columns>
        </DataGrid>
