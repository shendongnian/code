    <Grid Height="50" Width="100" Background="Red" Opacity="0">
            <Grid.Style>
                <Style TargetType="Grid">
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="MouseEnter">
                            <BeginStoryboard>
                                <Storyboard>
                                    <Storyboard  >
                                        <DoubleAnimation BeginTime="00:00:00"  Storyboard.TargetProperty="(UIElement.Opacity)" From="0" To="1" Duration="00:00:03"/>
                                    </Storyboard>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Style.Triggers>
                </Style>
            </Grid.Style>
        </Grid>
