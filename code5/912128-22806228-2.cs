    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Rectangle Fill="LightGreen">
            <Rectangle.Style>
                <Style>
                    <Style.Triggers>
                        <Trigger Property="UIElement.IsMouseOver" Value="True">
                            <Setter Property="Grid.ColumnSpan" Value="2" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Rectangle.Style>
        </Rectangle>
    </Grid>
