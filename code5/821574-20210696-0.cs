        <ListBox ItemsSource="{Binding OuterCollection}" SelectedItem="{Binding OuterListBoxSelectedItem}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding OuterProperty1}" />
                            <ListBox Width="200" ItemsSource="{Binding InnerCollection}" SelectedItem="{Binding InnerListBoxSelectedItem}">
                                <ListBox.ItemTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding InnerProperty1}" />
                                    </DataTemplate>
                                </ListBox.ItemTemplate>
                            </ListBox>
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
