    CustomObjects = new ObservableCollection<CustomObject>();
    CustomObject customObject = new CustomObject();
    foreach (KeyValuePair<string, string> entry in data)
    {
        if (entry.Key == "ID_Id") // Assuming this always comes first
        {
            customObject = new CustomObject();
            customObject.Id = int.Parse(entry.Value);
        }
        ...
        else if (entry.Key == "ID_Name") // Assuming this always comes lasst
        {
            customObject.Name = entry.Value;
            customObjects.Add(customObject);
        }
    }
    ...
    <ListBox ItemsSource="{Binding CustomObjects}">
        <ListBox.ItemTemplate>
            <DataTemplate DataType="{x:Type DataTypes:CustomObject}">
                <StackPanel>
                    <TextBox Text="{Binding Id}"/>
                    ...
                    <TextBox Text="{Binding Name}"/>
                </StackPanel>
            </DataTemplate DataType="{x:Type DataTypes:CustomObject}">
        </ListBox.ItemTemplate>
    </Window>
