    <TabControl>
            <TabItem  Header="{Binding Items}">
                <ContentPresenter Content="{Binding Items, Mode=OneTime}">
                    <ContentPresenter.ContentTemplate>
                        <DataTemplate>
                            <ListBox ItemsSource="{Binding}" />
                        </DataTemplate>
                    </ContentPresenter.ContentTemplate>
                </ContentPresenter>
                <TabItem.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal" Name="panel">
                            <TextBlock Text="Item Count"/>
                            <TextBlock Text="{Binding Count, StringFormat={}  {0}}"/>
                        </StackPanel>
                    </DataTemplate>
                </TabItem.HeaderTemplate>
            </TabItem>
        </TabControl>
