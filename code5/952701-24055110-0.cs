        <ItemsControl>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Expander Header="{Binding}" Margin="4">
                        exapnder data
                    </Expander>
                </DataTemplate>
                </ItemsControl.ItemTemplate>
            <ItemsControl.Items>
                <sys:String>Positions</sys:String>
                <sys:String>Orders</sys:String>
                <sys:String>Trade</sys:String>
            </ItemsControl.Items>
        </ItemsControl>
