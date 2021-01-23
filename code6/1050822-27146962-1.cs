    <Style TargetType="ToolTip">
        <Setter Property="OverridesDefaultStyle" Value="True" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate  TargetType="ToolTip">
                    <Border Background="GhostWhite" BorderBrush="Gainsboro" BorderThickness="1">
                    <Grid Background="White">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition />
                            <RowDefinition />
                        </Grid.RowDefinitions>
                        <Label Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="2"
                               Content="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ToolTip}}, 
                               Path=PlacementTarget.(dcr:ButtonDropDown.Header)}" 
                               FontWeight="Bold" />
                        <Viewbox Grid.Row="1" Grid.Column="0" Width="64" Height="32" Margin="3">
                            <ContentControl Content="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ToolTip}}, 
                                Path=PlacementTarget.(dcr:ButtonDropDown.Image)}" />
                        </Viewbox>
                        <Label Grid.Row="1" Grid.Column="1"
                               Content="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ToolTip}},
                               Path=PlacementTarget.(dcr:ButtonDropDown.ToolTip)}" />
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
