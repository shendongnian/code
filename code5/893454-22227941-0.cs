    <ListView Name="LV_Items">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="#">
                            <TextBlock.Visibility>
                                <MultiBinding Converter="{StaticResource NonEqualValuesToVisibilityConverter}">
                                    <Binding Path="ComboDefaultValue" Mode="OneWay"></Binding>
                                    <Binding ElementName="CB_Selection" Path="SelectedValue" Mode="OneWay"></Binding>
                                </MultiBinding>
                            </TextBlock.Visibility>
                        </TextBlock>
                        <ComboBox Name="CB_Selection"  
                                  ItemsSource="{Binding ComboItems}"
                                  DisplayMemberPath="Item2" 
                                  SelectedValue="{Binding ComboDefaultValue, Mode=OneTime}" 
                                  SelectedValuePath="Item1">
                        
                        </ComboBox>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
