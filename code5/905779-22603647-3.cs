    <ContextMenu>
       <MenuItem Header="Add To Selected Tournaments"
                 Command="{Binding RelativeSource={RelativeSource
                                   AncestorType={x:Type ContextMenu}},
                            Path=PlacementTarget.Tag.AddTournamentCommand}"/>
    </ContextMenu>
