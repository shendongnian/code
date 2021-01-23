        <Button Name="ContextMenuButton" 
                Content="Click me!" 
                Click="ContextMenuButton_Click" >
            <Button.ContextMenu>
                <ContextMenu Opened="ContextMenuButton_OnContextMenuOpening" Closed="ContextMenuButton_OnContextMenuClosing">
                    <MenuItem Header="First element" />
                    <MenuItem Header="Second element" />
                </ContextMenu>
            </Button.ContextMenu>
        </Button>
