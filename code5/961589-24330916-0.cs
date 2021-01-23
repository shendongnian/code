    <TextBlock Text="{Binding Text, ElementName=Box, NotifyOnTargetUpdated=True}"  Foreground="White" >
        <TextBlock.Style>
            <Style TargetType="TextBlock">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Binding.TargetUpdated">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimationUsingKeyFrames Duration="0:0:2" Storyboard.TargetProperty="Foreground.Color" >
                                    <SplineColorKeyFrame Value="#A933FF"/>
                                    <SplineColorKeyFrame Value="White" KeyTime="0:0:1"/>
                                </ColorAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </TextBlock.Style>
    </TextBlock>
