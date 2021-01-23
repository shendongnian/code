                        <Menu>
                            <MenuItem ItemsSource="{Binding AgeSelectors}" ItemsPanel="{StaticResource MenuItemPanelTemplate}"  ToolTip="Select which items are included/excluded in the view" Foreground="Wheat">
                                <MenuItem.Header>
                                    <StackPanel>
                                        <Image Source="Resources/Images/Tango/appointment-new.png" />
                                        <TextBlock Text="Age" Foreground="Navy"/>
                                    </StackPanel>
                                </MenuItem.Header>
                                <MenuItem.ItemTemplate>
                                    <DataTemplate>
                                        <MenuItem IsCheckable="True" 
                                              IsChecked="{Binding IsChecked, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                              >
                                            <MenuItem.Header>
                                                <StackPanel Orientation="Horizontal">
                                                    <TextBlock Text="{Binding Description}"/>
                                                </StackPanel>
                                            </MenuItem.Header>
                                        </MenuItem>
                                    </DataTemplate>
                                </MenuItem.ItemTemplate>
                            </MenuItem>
                        </Menu>
