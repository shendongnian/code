        <telerik:RadComboBox ItemsSource="{Binding YourCollectionOfProperties}">
            <telerik:RadComboBox.ItemTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding YourPropertyDescription}" IsChecked="{Binding IsPropertySelected}"/>
                </DataTemplate>
            </telerik:RadComboBox.ItemTemplate>
        </telerik:RadComboBox>
