    <ComboBox Loaded="ComboBox_Loaded">
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem Content="All" />
                <CollectionContainer Collection="{Binding Source={StaticResource AllBitsSource}}" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
