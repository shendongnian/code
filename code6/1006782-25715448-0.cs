        <TextBlock x:Name="HiddenItemWithDataContext" Visibility="Collapsed" />
        <TabControl x:Name="Tab1" SelectionChanged="Tab1_SelectionChanged" >
            <TabControl.ItemsSource>
                <CompositeCollection>
                    <CollectionContainer Collection="{Binding DataContext.MyList, Source={x:Reference HiddenItemWithDataContext}}" />
                    <TabItem  Header="+" x:Name="AddTabButton"/>
                </CompositeCollection>
            </TabControl.ItemsSource>
        </TabControl>
