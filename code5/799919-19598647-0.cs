    <Button Content="Submit" >
    	<Button.ContextMenu>
    		<ContextMenu Name="SubmitButtonContextMenu">
    			<ContextMenu.ItemsSource>
    				<CompositeCollection>
    					<MenuItem Header="First static item" />
    					<MenuItem Header="Second static item" />
    					<Separator />
    					<CollectionContainer Collection="{Binding MyDataSource}" />
    				</CompositeCollection>
    			</ContextMenu.ItemsSource>
    		</ContextMenu>
    	</Button.ContextMenu>
    </Button>
