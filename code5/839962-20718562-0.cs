     <Style TargetType="Button">
            
            <Style.Triggers>
                <EventTrigger RoutedEvent="Button.Click">
                    <EventTrigger.Actions>
                        
                        <BeginStoryboard>
                            
                            <Storyboard>
                                
                                <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsEnabled">
                                    
                                    <DiscreteBooleanKeyFrame KeyTime="00:00:00" Value="False" />
                                    <DiscreteBooleanKeyFrame KeyTime="00:00:30" Value="True" />
                                </BooleanAnimationUsingKeyFrames>
                                
                            </Storyboard>
                            
                        </BeginStoryboard>
                        
                    </EventTrigger.Actions>
                </EventTrigger>
            </Style.Triggers>
            
        </Style>
