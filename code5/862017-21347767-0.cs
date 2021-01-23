                <DataGrid.Style>
                <Style TargetType="DataGrid">
                    <Setter Property="AlternatingRowBackground" Value="LightGray"/>
                </Style>
            </DataGrid.Style>
            <DataGrid.RowStyle>
                <Style TargetType="DataGridRow">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Highlight}" Value="True">
                            <Setter Property="Background" Value="Yellow" />
                        </DataTrigger>
                        <Trigger Property="IsSelected" Value="True">
                            <Setter Property="Background" Value="#FF3CF1C8" />
                            <Setter Property="BorderBrush" Value="#FF3CF1C8" />
                        </Trigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding IsSelected, RelativeSource={RelativeSource Mode=Self}}" Value="True"/>
                                <Condition Binding="{Binding Highlight}" Value="True"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Background" Value="#FFFBAE8A" />
                            <Setter Property="BorderBrush" Value="#FFFBAE8A" />
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </DataGrid.RowStyle>
            <DataGrid.CellStyle>
                <Style TargetType="DataGridCell">
                    <Style.Triggers>
                        <Trigger Property="IsSelected" Value="True">
                            <Setter Property="Background" Value="#FF3CF1C8" />
                            <Setter Property="BorderBrush" Value="#FF3CF1C8" />
                        </Trigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding IsSelected, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type DataGridRow}}}" Value="True"/>
                                <Condition Binding="{Binding Highlight}" Value="True"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Background" Value="#FFFBAE8A" />
                            <Setter Property="BorderBrush" Value="#FFFBAE8A" />
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </DataGrid.CellStyle>
