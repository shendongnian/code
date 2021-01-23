    <Storyboard x:Key="showsearchtextbox">
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TranslateTransform.Y)" Storyboard.TargetName="searchtextbox">
            <DiscreteDoubleKeyFrame KeyTime="0" Value="-100"/>
            <EasingDoubleKeyFrame KeyTime="0:0:0.500" Value="0">
                <EasingDoubleKeyFrame.EasingFunction>
                    <CubicEase EasingMode="EaseOut"/>
                </EasingDoubleKeyFrame.EasingFunction>
            </EasingDoubleKeyFrame>
        </DoubleAnimationUsingKeyFrames>
    </Storyboard>
