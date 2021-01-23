    <DataTemplate DataType="{x:Type model:Player}">
        <Canvas>               
            <Grid Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType={x:Type ItemsControl}}} Canvas.Left="{Binding Location.X}"
                  Canvas.Top="{Binding Location.Y}"
                  MouseLeftButtonDown="Grid_MouseLeftButtonDown"
                  MouseLeftButtonUp="Grid_MouseLeftButtonUp"
                  MouseMove="Grid_MouseMove">
                <Grid.ContextMenu>
                    <ContextMenu>
                            <MenuItem Header="Remove" 
                             Command="{Binding PlacementTarget.Tag.RemoveCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}" 
                             CommandParameter="{Binding PlacementTarget.DataContext, 
              RelativeSource={RelativeSource FindAncestor, 
              AncestorType={x:Type ContextMenu}}}"/>
                        </ContextMenu>
                </Grid.ContextMenu>
                <Grid.LayoutTransform>
                    <RotateTransform Angle="-90" />
                </Grid.LayoutTransform>
                <Ellipse Width="12"
                         Height="12" 
                         Fill="{Binding PrimaryColor}" />
                <TextBlock HorizontalAlignment="Center"
                           VerticalAlignment="Center"
                           FontSize="6"
                           FontWeight="Bold"
                           Foreground="Black"
                           Text="{Binding Position.Abbreviation}" />
            </Grid>
        </Canvas>
    </DataTemplate>
