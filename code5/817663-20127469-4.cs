    <DataTemplate.Triggers>
    <DataTrigger Binding="{Binding IsRemoving}" Value="True">
        <DataTrigger.EnterActions>
            <BeginStoryboard>
                <Storyboard>
                    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.LayoutTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" Storyboard.TargetName="border">
                        <EasingDoubleKeyFrame KeyTime="0" Value="1">
                            <EasingDoubleKeyFrame.EasingFunction>
                                <QuinticEase EasingMode="EaseOut"></QuinticEase>
                            </EasingDoubleKeyFrame.EasingFunction>
                        </EasingDoubleKeyFrame>
                        <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="0">
                            <EasingDoubleKeyFrame.EasingFunction>
                                <QuinticEase EasingMode="EaseOut"></QuinticEase>
                            </EasingDoubleKeyFrame.EasingFunction>
                        </EasingDoubleKeyFrame>
                    </DoubleAnimationUsingKeyFrames>
                </Storyboard>
            </BeginStoryboard>
        </DataTrigger.EnterActions>
    </DataTrigger>
