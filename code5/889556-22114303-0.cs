    <Grid.Triggers>
                <EventTrigger RoutedEvent="FrameworkElement.Loaded">
                    <BeginStoryboard>
                        <Storyboard>
                            <ThicknessAnimation Storyboard.TargetProperty="(Grid.Margin)" Duration="0:0:20" From="518,3,-518,-3" To="0"/>
                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" >
                                <SplineDoubleKeyFrame KeyTime="0:0:2" Value="1"/>
                                <SplineDoubleKeyFrame KeyTime="0:0:15" Value="0"/>
                            </DoubleAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
                </Grid.Triggers>
