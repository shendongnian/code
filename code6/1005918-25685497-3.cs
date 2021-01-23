    <ListBox>
        <ItemsControl ItemsSource="{Binding LineRouteCollection}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Expander Header="{Binding Name}" MinHeight="70">                            
                        <ListBox>
                            <ItemsControl ItemsSource ="{Binding AllStopsCollection}">
                                <ItemsControl.ItemTemplate> <!-- You forgot this ItemTemplate -->
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Name}"></TextBlock>
                                   </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                       </ListBox>
                    </Expander>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </ListBox>
