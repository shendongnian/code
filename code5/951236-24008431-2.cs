      <ComboBox ItemsSource="{Binding ItemList}" SelectedItem="{Binding SelectedItem}" >
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <myControls:MyUserControl/>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
