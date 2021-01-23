    <Storyboard x:Name="ShowThatFunkyEllipse">
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)" Storyboard.TargetName="MyMovingElement">
            <EasingDoubleKeyFrame KeyTime="0" Value="-350"/>
            <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="0" />
        </DoubleAnimationUsingKeyFrames>
    </Storyboard>
    ... snip ...
    <Ellipse x:Name="MyMovingElement">
        <Ellipse.RenderTransform>
            <CompositeTransform TranslateX="-350" />
        </Ellipse.RenderTransform>
    </Ellipse>
