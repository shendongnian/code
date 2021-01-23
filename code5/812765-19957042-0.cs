    <ItemsControl ItemsSource="{Binding Items}" Margin="20 20 20 0">
    	<ItemsControl.ItemsPanel>
    		<ItemsPanelTemplate>
    			<WrapPanel Orientation="Horizontal"/>
    		</ItemsPanelTemplate>
    	</ItemsControl.ItemsPanel>
    	<ItemsControl.ItemTemplate>
    		<HierarchicalDataTemplate>
    			<Button Content="{Binding Title}" ToolTip="{Binding ToolTip}"/>
    			<HierarchicalDataTemplate.ItemTemplate>
    				<DataTemplate >
    					<Button Content="{Binding Title}" ToolTip="{Binding ToolTip}"/>
    				</DataTemplate >
    			</HierarchicalDataTemplate.ItemTemplate>
    		</HierarchicalDataTemplate>
    	</ItemsControl.ItemTemplate>
    </ItemsControl>
