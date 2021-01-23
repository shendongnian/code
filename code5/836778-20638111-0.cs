    <UserControl ...>
        <UserControl.Resources>
            <local:InternalItemConverter x:Key="InternalItemConverter"/>
        </UserControl.Resources>
        <DockPanel>
            ...
            <ComboBox>
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding
                            Converter={StaticResource InternalItemConverter}}"/>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
        </DockPanel>
    </UserControl>
