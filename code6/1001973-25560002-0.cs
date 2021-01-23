        <ComboBox>
            <ComboBox.ItemsSource>
                <CompositeCollection>
                    <ComboBoxItem>All</ComboBoxItem>
                    <CollectionContainer Collection="{Binding ProductsList}" />
                </CompositeCollection>
            </ComboBox.ItemsSource>
        </ComboBox>
