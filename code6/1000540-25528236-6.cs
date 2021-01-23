    <ComboBox Grid.Row="1" Grid.Column="1" Grid.ColumnSpan="2"
                      ItemsSource="{Binding BillingCycles}" SelectedItem="{Binding SelectedBillingCycle}">
                <ComboBox.ItemTemplateSelector>
                    <b:ComboBoxItemTemplateSelector>
                        <b:ComboBoxItemTemplateSelector.SelectedTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding BillingCycleDescription}">
                                    <TextBlock.Foreground>
                                        <MultiBinding Converter="{StaticResource IsCurrentCycleColorConverter}">
                                            <Binding Path="ItemsSource" RelativeSource="{RelativeSource AncestorType={x:Type ComboBox}}"/>
                                            <Binding Path="SelectedItem" RelativeSource="{RelativeSource AncestorType={x:Type ComboBox}}"/>
                                        </MultiBinding>
                                    </TextBlock.Foreground>
                                </TextBlock>
                            </DataTemplate>
                        </b:ComboBoxItemTemplateSelector.SelectedTemplate>
                        <b:ComboBoxItemTemplateSelector.DropDownTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding BillingCycleDescription}" />
                            </DataTemplate>
                        </b:ComboBoxItemTemplateSelector.DropDownTemplate>
                    </b:ComboBoxItemTemplateSelector>
                </ComboBox.ItemTemplateSelector>
            </ComboBox>
