    <Storyboard x:Key="Curtain">
       <DoubleAnimationUsingKeyFrames 
                           Storyboard.TargetProperty="(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Offset)"                                                                          
                           Storyboard.TargetName="border">
          <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
        </DoubleAnimationUsingKeyFrames>
        <DoubleAnimationUsingKeyFrames 
                           Storyboard.TargetProperty="(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Offset)"                                                                          
                           Storyboard.TargetName="border">
           <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
         </DoubleAnimationUsingKeyFrames>
    </Storyboard>
