    <Storyboard x:Name="MyStoryboard1" Storyboard.TargetName="MyPolygon"  Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)">
        <DoubleAnimationUsingKeyFrames BeginTime="00:00:00.000">
            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="300">
                <EasingDoubleKeyFrame.EasingFunction>
                    <CubicEase EasingMode="EaseOut"/>
                </EasingDoubleKeyFrame.EasingFunction>
            </EasingDoubleKeyFrame>
            <EasingDoubleKeyFrame KeyTime="0:0:1.5" Value="0">
                <EasingDoubleKeyFrame.EasingFunction>
                    <CubicEase EasingMode="EaseOut"/>
                </EasingDoubleKeyFrame.EasingFunction>
            </EasingDoubleKeyFrame>
        </DoubleAnimationUsingKeyFrames>
    </Storyboard>
