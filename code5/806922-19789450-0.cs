    <ComboBox ItemsSource="{Binding Binding Sections}" SelectedItem="{Binding SelectedSection, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="Hello World!"/>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
