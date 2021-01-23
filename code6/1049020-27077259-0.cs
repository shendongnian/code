    <TreeView Name="treeView_max" >
        <TreeView.Resources>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal" >
                                <RadioButton Name="chk" Margin="2" Tag="{Binding}" GroupName="SomeGroup">
                                    <RadioButton.Template>
                                        <ControlTemplate>
                                            <CheckBox IsChecked="{Binding IsChecked, Mode=TwoWay, RelativeSource={RelativeSource AncestorType=RadioButton}}" />
                                        </ControlTemplate>
                                    </RadioButton.Template>
                                </RadioButton>
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TreeView.Resources>
    </TreeView>
