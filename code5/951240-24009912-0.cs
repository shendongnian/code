        <ComboBox ItemsSource="{Binding UserControlList}" SelectedItem="{Binding SelectedUserControl}">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding ItemName}"/>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
