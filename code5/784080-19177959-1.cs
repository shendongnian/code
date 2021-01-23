      <DataGrid>
            <DataGrid.Columns>
                <DataGridCheckBoxColumn>
                    <DataGridCheckBoxColumn.ElementStyle>
                        <Style TargetType="Checkbox">
                            <Style.Triggers>
                                <MultiDataTrigger>
                                    <MultiDataTrigger.Conditions>
                                        <Condition Binding="{Binding HasMaxNumberReached, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" Value="true"/>
                                        <Condition Binding="{Binding IsChecked, RelativeSource={RelativeSource Self}}" Value="false"/>
                                    </MultiDataTrigger.Conditions>
                                    <Setter Property="IsEnabled" Value="False"/>
                                </MultiDataTrigger>                               
                            </Style.Triggers>
                        </Style>
                    </DataGridCheckBoxColumn.ElementStyle>
                </DataGridCheckBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
