    <Window.Resources>
       <CollectionViewSource x:Key="ExistingTabs" Source="{Binding ExistingTabs}"/>
    </Window.Resources>
    <TabControl>
        <TabControl.ItemsSource>
            <CompositeCollection>
                 <TabItem>SpecialItem</TabItem>
                 <CollectionContainer Collection="{Binding Source={StaticResource ExistingTabs}}"/>
             </CompositeCollection>
        </TabControl.ItemsSource>
    </TabControl>
