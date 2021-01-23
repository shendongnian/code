    <TabControl Name="tc">
            <TabControl.ItemsSource>
                <CompositeCollection>
                    <TabItem Header="extra tab item"> //Not bound
                        <TextBox>something</TextBox>
                    </TabItem>
                    <CollectionContainer x:Name="cc"/>
                </CompositeCollection>
            </TabControl.ItemsSource>
        </TabControl>
