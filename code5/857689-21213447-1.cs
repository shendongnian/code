    <ListBox>
        <ListBox.Resources>
            <DataTemplate DataType="Person">
                <TextBlock Text="PersonName" />
            </DataTemplate>
            <DataTemplate DataType="Business[not(ContactName)]">
                <TextBlock Text="BusinessName" />
            </DataTemplate>
            <DataTemplate DataType="Business[ContactName]">
                <StackPanel>
                    <TextBlock Text="ContactName" />
                    <TextBlock Text="BusinessName" />
                </StackPanel>
            </DataTemplate>
        </ListBox.Resources>
    </ListBox>
