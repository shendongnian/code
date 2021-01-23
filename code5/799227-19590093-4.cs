    <Window.Resources>
      ...
      <Storyboard x:Key="RotateC">
        <DoubleAnimationUsingKeyFrames 
            Storyboard.TargetProperty="(UIElement.RenderTransform).(RotateTransform.Angle)" 
            Storyboard.TargetName="currentDeviancePointer_s">
            <EasingDoubleKeyFrame KeyTime="0" Value="0"/>
            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="{Binding ValueToRotate}"/>
        </DoubleAnimationUsingKeyFrames>
      </Storyboard>
    </Window.Resources>
