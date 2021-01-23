    <DataGrid x:Name="grid" AutoGenerateColumns="False">
            <DataGrid.Resources>
                <Style TargetType="CheckBox" x:Key="style">
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding HasMaxNumberReached, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" Value="true"/>
                                <Condition Binding="{Binding IsChecked, RelativeSource={RelativeSource Self}}" Value="false"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="IsEnabled" Value="False"/>
                        </MultiDataTrigger>
                    </Style.Triggers>
                    <EventSetter Event="CheckBox.Checked" Handler="DataGridCheckBoxColumn_Checked" />
                    <EventSetter Event="CheckBox.Unchecked" Handler="DataGridCheckBoxColumn_Checked" />
                </Style>
            </DataGrid.Resources>
            <DataGrid.Columns>
            <DataGridCheckBoxColumn x:Name="IsFixedByBracketColumn"  Header="Fissato con staffa" 
                                    Binding="{Binding isFixedByBracket, UpdateSourceTrigger=PropertyChanged}" IsReadOnly="False"
                                    ElementStyle="{StaticResource style}" EditingElementStyle="{StaticResource style}">
                
            </DataGridCheckBoxColumn>
            </DataGrid.Columns>
        </DataGrid> 
