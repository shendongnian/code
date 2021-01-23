    <UserControl x:Class="Spas.DayControl" >
        <ItemsControl x:Name="MyShifts" ItemsSource="{Binding ShiftObjects}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <local:Spas.ShiftControl />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Vertical"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
        </ItemsControl>
    </UserControl>
