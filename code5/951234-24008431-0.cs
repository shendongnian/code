      <ComboBox ItemsSource="{Binding ItemList}" SelectedItem="{Binding SelectedItem}" DisplayMemberPath="ItemName"  >
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <myControls:MyUserControl/>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
