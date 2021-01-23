    <MenuItem Header="Click Me">
        <MenuItem.Triggers>
            <EventTrigger RoutedEvent="MenuItem.Click">
                <BeginStoryboard>
                    <Storyboard>
                        <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="(MenuItem.IsEnabled)">
                            <DiscreteBooleanKeyFrame KeyTime="0" Value="False" />
                        </BooleanAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </MenuItem.Triggers>
    </MenuItem>
