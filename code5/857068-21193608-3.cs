    <ListBox Height="340" ItemsSource="{Binding Sections}" SelectedItem="{Binding SelectedSection}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <ListBoxItem IsSelected="{Binding IsChecked}">
                    <CheckBox IsChecked="{Binding IsChecked}" Content="{Binding Path=Item}" />
                </ListBoxItem>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
