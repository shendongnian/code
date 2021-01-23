    <Storyboard x:Key="RadialStoryBoard" RepeatBehavior="Forever">
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Rectangle.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Offset)" Storyboard.TargetName="RadialTest">
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value="0.125" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Rectangle.Fill).(GradientBrush.GradientStops)[2].(GradientStop.Offset)" Storyboard.TargetName="RadialTest">
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value=".25" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Rectangle.Fill).(GradientBrush.GradientStops)[3].(GradientStop.Offset)" Storyboard.TargetName="RadialTest">
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value=".375" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Rectangle.Fill).(GradientBrush.GradientStops)[4].(GradientStop.Offset)" Storyboard.TargetName="RadialTest">
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value=".5" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Rectangle.Fill).(GradientBrush.GradientStops)[5].(GradientStop.Offset)" Storyboard.TargetName="RadialTest">
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value=".625" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Rectangle.Fill).(GradientBrush.GradientStops)[6].(GradientStop.Offset)" Storyboard.TargetName="RadialTest">
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value=".75" />
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Rectangle.Fill).(GradientBrush.GradientStops)[7].(GradientStop.Offset)" Storyboard.TargetName="RadialTest">
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value=".875" />
            </DoubleAnimationUsingKeyFrames>
    </Storyboard>
    <RadialGradientBrush Center="0.5,0.5" RadiusX="1" RadiusY="1" GradientOrigin="0.5,0.5"  MappingMode="RelativeToBoundingBox">
          <GradientStop Color="Yellow" Offset="0"/>
          <GradientStop Color="Black" Offset="0"/>
          <GradientStop Color="Yellow" Offset="0"/>
          <GradientStop Color="Black" Offset=".125"/>
          <GradientStop Color="Yellow" Offset=".25"/>
          <GradientStop Color="Black" Offset=".375"/>
          <GradientStop Color="Yellow" Offset=".5"/>
          <GradientStop Color="Black" Offset=".625"/>   
    </RadialGradientBrush>
