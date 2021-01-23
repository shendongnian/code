    <Button Name="Button_1" >
            <Button.ContextMenu>
                <ContextMenu x:Name="MainContextMenu">
                    <MenuItem IsCheckable="True" IsChecked="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=ContextMenu}, Path=PlacementTarget.DataContext.AskBeforeDownloading_Checked}" />
                </ContextMenu>
            </Button.ContextMenu>
        </Button>
