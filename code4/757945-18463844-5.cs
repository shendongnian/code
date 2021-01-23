                        <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <DataTemplate.Resources>
                                <local:DynamicValuesConverter x:Key="DependedValuesConverter" />
                            </DataTemplate.Resources>
                            <ComboBox SelectedValue="{Binding P_Unit}" ItemsSource="{Binding PlacementHeader, Converter={StaticResource DependedValuesConverter}}"></ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
