     <Grid Background="Black">
        <Grid x:Name="grid2" Width="250" Height="250" Background="Blue" Grid.Column="1">
            <Grid.Projection>
                <PlaneProjection/>
            </Grid.Projection>
            <Grid.Triggers>
                <EventTrigger>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimationUsingKeyFrames EnableDependentAnimation="True" Storyboard.TargetProperty="(UIElement.Projection).(PlaneProjection.RotationY)" Storyboard.TargetName="grid2">
                                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="0"/>
                                <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="40"/>
                                <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="60"/>
                                <EasingDoubleKeyFrame KeyTime="0:0:0.15" Value="0"/>
                            </DoubleAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Grid.Triggers>
        </Grid>
    </Grid>
