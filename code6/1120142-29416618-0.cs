    <Button Name="Button_1" >
        <Button.ContextMenu>
            <ContextMenu x:Name="MainContextMenu" DataContext="{Binding PlacementTarget.DataContext, RelativeSource={RelativeSource Self}}" >
                <MenuItem IsCheckable="True" IsChecked="{Binding AskBeforeDownloading_Checked}" />
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
