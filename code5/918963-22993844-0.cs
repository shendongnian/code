    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Rectangle Fill="Blue" Grid.Column="0" x:Name="blueRectangle">
            <Rectangle.Style>
                <Style TargetType="Rectangle">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Visibility,
                                    ElementName=redRectangle}" Value="Collapsed">
                            <Setter Property="Grid.ColumnSpan" Value="2"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Rectangle.Style>
        </Rectangle>
        <Rectangle Fill="Red" Grid.Column="1" x:Name="redRectangle">
            <Rectangle.Style>
                <Style TargetType="Rectangle">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Visibility, 
                                     ElementName=blueRectangle}" Value="Collapsed">
                            <Setter Property="Grid.ColumnSpan" Value="2"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Rectangle.Style>
        </Rectangle>
    </Grid>
