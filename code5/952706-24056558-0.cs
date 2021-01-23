    <Expander>
        <Expander.Header>
            <TabControl>
                <TabItem x:Name="PositionsTabHeader" Header="Positions"/>
                <TabItem x:Name="OrdersTabHeader" Header="Orders"/>
                <TabItem x:Name="TradesTabHeader" Header="Trades"/>
            </TabControl>
        </Expander.Header>
        <TabControl>
            <TabItem Visibility="Collapsed"
                     IsSelected="{Binding ElementName=PositionsTabHeader, Path=IsSelected}">
                Positions go here
            </TabItem>
            <TabItem Visibility="Collapsed"
                     IsSelected="{Binding ElementName=OrdersTabHeader, Path=IsSelected}">
                Orders go here
            </TabItem>
            <TabItem Visibility="Collapsed"
                     IsSelected="{Binding ElementName=TradesTabHeader, Path=IsSelected}">
                Trades go here
            </TabItem>
        </TabControl>
    </Expander>
