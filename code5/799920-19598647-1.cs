    <Window ..
           >
        <Window.Resources>
            <CollectionViewSource x:Key="MyDynamicDataSource" Source="{Binding Path=MyDataSource}" />
    	...
    	</Window.Resources>
    	...
    	<Button Content="Submit" >
    		<Button.ContextMenu>
    			<ContextMenu Name="SubmitButtonContextMenu">
    				<ContextMenu.ItemsSource>
    					<CompositeCollection>
    						<MenuItem Header="First static item" />
    						<MenuItem Header="Second static item" />
    						<Separator />
    						<CollectionContainer Collection="{Binding Source={StaticResource MyDynamicDataSource}}" />
    					</CompositeCollection>
    				</ContextMenu.ItemsSource>
    			</ContextMenu>
    		</Button.ContextMenu>
    	</Button>
    	...
    </Window>
	
