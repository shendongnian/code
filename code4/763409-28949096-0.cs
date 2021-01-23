                                <ContextMenu x:Key="MyRowMenu1" DataContext="{Binding PlacementTarget, RelativeSource={RelativeSource Self}}">
                                    <MenuItem Click="MenuItem_Click" Header="Add to Favourites"/>
                                    <MenuItem Header="Copy" >
                                        <MenuItem Header="Copy Name"/>
                                        <MenuItem Header="Copy ID" />
                                        <MenuItem Header="Copy IP Adddress"/>
                                    </MenuItem>
                                </ContextMenu>
