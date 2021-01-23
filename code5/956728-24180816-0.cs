    <Label Name="SomeName" Visibility="Hidden" Content="Something">
        <Label.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard BeginTime="0:0:1">
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility">
                            <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" />
                        </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Label.Triggers>
    </Label>
