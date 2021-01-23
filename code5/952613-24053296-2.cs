        <TextBox>
            <TextBox.Triggers>
                <EventTrigger RoutedEvent="TextBox.TextChanged" >
                    <BeginStoryboard>
                        <Storyboard>
                            <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="DataContext.TextChanged" >
                                <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="False" />
                                <DiscreteBooleanKeyFrame KeyTime="0:0:1" Value="True"/>
                            </BooleanAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </TextBox.Triggers>
        </TextBox>
