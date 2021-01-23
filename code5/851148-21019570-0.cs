    Make change in your xaml and cs code like this:
     
     <Grid x:Name="ContentPanel" Grid.Row="1" Height="Auto">
                    <ListBox x:Name="lstDevice" SelectionChange="item_Select">
                        <ListBox.ItemsPanel>
                            <ItemsPanelTemplate>
                                <toolkit:WrapPanel/>                        
                            </ItemsPanelTemplate>
                        </ListBox.ItemsPanel>
                        <ListBox.ItemTemplate>
                            <DataTemplate >
                                <StackPanel>
                                    <Button x:Name="btnData" >
                                        <StackPanel Orientation="Vertical">
                                            <Canvas 
                                                    Width="175" 
                                                    Height="175"/>                                            
                                            <TextBlock Text="{Binding Name}" Width="175" />
                                        </StackPanel>
                                    </Button>
                                </StackPanel>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </Grid>
        
        
            private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
                {
                    lstDevice.ItemsSource = MainPage.user.dArray.ToList();            
                   
                }
        
                private void item_Select(object sender, SelectionChangedEventArgs e)
                {
                    var selctedItem  = lstDevice.SelectedItem as (Your list box's itmsource)
                }
