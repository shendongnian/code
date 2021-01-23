    <ComboBox>
        <ComboBox.Resources>
            <CollectionViewSource x:Key="Products" Source="{Binding ProductsList}"/>
        </ComboBox.Resources>
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem>All</ComboBoxItem>
                <CollectionContainer Collection="{Binding Source={StaticResource Products}}" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
