    <ListBox x:Name="Results" Height="450" HorizontalAlignment="Left" VerticalAlignment="Bottom" ItemsSource="{Binding Items}">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel Margin="20,0,0,20" Tap="ItemTapped">
                                        <TextBlock Text="{Binding SearchVal}"  TextWrapping="Wrap" FontSize="{StaticResource PhoneFontSizeMediumLarge}" />
                                        <TextBlock Text="{Binding Category}"  TextWrapping="Wrap" FontSize="{StaticResource PhoneFontSizeMedium}" />
                                    </StackPanel>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
    private void ItemTapped(object sender, GestureEventArgs e)
        {
            var element = sender as FrameworkElement; //
            if (element != null)
            {
                var selectedVal = element.DataContext as TestMap.Classes.Global.Place;
                Classes.Global.searchedValue = "Test to get into the loop in main";
                if (selectedVal != null)
                {
                    Classes.Global.posy = selectedVal.Y;
                    Classes.Global.posx = selectedVal.X;
                }
                NavigationService.GoBack();
            }
        }
