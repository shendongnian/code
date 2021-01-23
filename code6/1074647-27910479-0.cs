    <ItemsControl ...>
          <ItemsControl.ItemTemplate>
              <DataTemplate DataType="local:VoltageMonitor">
                  <Grid ..>
                      <Grid.ContextMenu>
                          <ContextMenu>
                              <MenuItem Header="Edit Format..." />
                              <MenuItem Header="Turn off" 
                                  CommandParameter="{Binding}"
                                  Command="{Binding RelativeSource=
                                       {RelativeSource Mode=FindAncestor, 
                                          AncestorType={x:Type ItemsControl}}, 
                                        Path=DataContext.TurnOffCommand}"/>
                          </ContextMenu>
                      </Grid.ContextMenu>
