    <Rectangle Width="100"
                   Height="100"
                   VerticalAlignment="Bottom"
                   Fill="Red">
            <Rectangle.RenderTransform>
                <TranslateTransform />
            </Rectangle.RenderTransform>
            <Rectangle.Triggers>
                <EventTrigger RoutedEvent="Loaded">
                    <BeginStoryboard>
                        <Storyboard RepeatBehavior="Forever">
                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TranslateTransform.Y)">
                                <EasingDoubleKeyFrame KeyTime="0:0:1"
                                                      Value="-200">
                                    <EasingDoubleKeyFrame.EasingFunction>
                                        <ElasticEase />
                                    </EasingDoubleKeyFrame.EasingFunction>
                                </EasingDoubleKeyFrame>
                            </DoubleAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Rectangle.Triggers>
        </Rectangle>
