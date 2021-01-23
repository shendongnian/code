    <Button x:Name="btnView" Tag="{Binding RelativeSource={RelativeSource FindAncestor,
            AncestorType={x:Type UserControl}},Path=DataContext}"
        <Button.ContextMenu >
            <ContextMenu x:Name="contextMenu" DataContext="{Binding PlacementTarget.Tag,
                RelativeSource={RelativeSource Self}}">
                <MenuItem Header="View" Command="{Binding CommandObj.ViewCommand}"/>
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
