     <Storyboard x:Name="Storyboard1" Completed="Storyboard_Completed_1">
                    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="arc">
                        <EasingDoubleKeyFrame KeyTime="0" Value="-555">
                            <EasingDoubleKeyFrame.EasingFunction>
                                <BounceEase EasingMode="EaseOut"/>
                            </EasingDoubleKeyFrame.EasingFunction>
                        </EasingDoubleKeyFrame>
                        <DiscreteDoubleKeyFrame KeyTime="0:0:5" Value="-150"/>
    
                    </DoubleAnimationUsingKeyFrames>
                </Storyboard>
