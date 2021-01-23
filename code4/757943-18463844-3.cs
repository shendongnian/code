                        <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <DataTemplate.Resources>
                                <local:DynamicValuesConverter x:Key="DependedValuesConverter" />
                            </DataTemplate.Resources>
                            <ComboBox SelectedValue="{Binding Value}" ItemsSource="{Binding Value, Converter={StaticResource DependedValuesConverter}}"></ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
