    <Rectangle Fill="Azure" Height="50" Width="50" Name="Rect1">
        <Rectangle.Resources>
            <Storyboard x:Key="Animation" >
                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="Transform"
                                        Storyboard.TargetProperty="X"
                                        RepeatBehavior="Forever"
                                        AutoReverse="True"        >
                            
                    <LinearDoubleKeyFrame KeyTime="0:0:02" Value="100" />
                    <LinearDoubleKeyFrame KeyTime="0:0:02" Value="0"   />
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="Transform"
                                        Storyboard.TargetProperty="Y"
                                        RepeatBehavior="Forever"
                                                AutoReverse="True">
                            
                    <LinearDoubleKeyFrame KeyTime="0:0:01" Value="100" />
                    <LinearDoubleKeyFrame KeyTime="0:0:01" Value="0"   />
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Rectangle.Resources>
        <Rectangle.RenderTransform>
            <TranslateTransform x:Name="Transform"/>
        </Rectangle.RenderTransform>
    </Rectangle>
    //in code behind
    (Rect1.Resources["Animation"] as Storyboard).Begin();
