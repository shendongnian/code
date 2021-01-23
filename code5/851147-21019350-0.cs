    <Grid x:Name="ContentPanel" Grid.Row="1" Height="Auto">
                <ListBox x:Name="lstDevice">
                    <ListBox.ItemsPanel>
                        <ItemsPanelTemplate>
                            <toolkit:WrapPanel/>                        
                        </ItemsPanelTemplate>
                    </ListBox.ItemsPanel>
                    <ListBox.ItemTemplate>
                        <DataTemplate >
                                <Button x:Name="btnData" Click="OnButtonClick" Tag="{Binding Name}" >
                                    <StackPanel Orientation="Vertical">
                                        <Canvas 
                                                Width="175" 
                                                Height="175"/>                                            
                                        <TextBlock Text="{Binding Name}" Width="175" />
                                    </StackPanel>
                                </Button>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
            </Grid>
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            lstDevice.ItemsSource = MainPage.user.dArray.ToList();            
        }
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            var nameInTag=b.Tag.ToString();
        }
