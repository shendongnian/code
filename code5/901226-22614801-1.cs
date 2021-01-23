    <Window.Resources>
        <Storyboard x:Key="FlipNumberStoryBoard">
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleX)" Storyboard.TargetName="Img1Top">
                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="5"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="10"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="20"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="35"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="60"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="75"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="88"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="Img1Top">
                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="-2.01"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="-3.45"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="-5.55"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="-7"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="-8.75"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="-9.5"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="-8.25"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" Storyboard.TargetName="Img1Top">
                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="0.90"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="0.80"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="0.60"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="0.40"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="0.20"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="0.10"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="0.01"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)" Storyboard.TargetName="Img1Top">
                <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="2.5"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="5"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="10.1"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="15"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="20"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="22.6"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="24.9"/>
            </DoubleAnimationUsingKeyFrames>
            <Int32AnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.ZIndex)" Storyboard.TargetName="Img2Bottom">
                <EasingInt32KeyFrame KeyTime="0:0:0.8" Value="1"/>
            </Int32AnimationUsingKeyFrames>
            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="Img1Top">
                <DiscreteObjectKeyFrame KeyTime="0:0:0.8" Value="{x:Static Visibility.Collapsed}"/>
            </ObjectAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleX)" Storyboard.TargetName="Img2Bottom">
                <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="-88"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="-75"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1" Value="-60"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.1" Value="-35"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.2" Value="-20"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.3" Value="-10"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.4" Value="-5"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.5" Value="0"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" Storyboard.TargetName="Img2Bottom">
                <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="0.01"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="0.10"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1" Value="0.20"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.1" Value="0.40"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.2" Value="0.60"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.3" Value="0.80"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.4" Value="0.90"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.5" Value="1"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="Img2Bottom">
                <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="-9.121"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="-8.87"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1" Value="-8.564"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.1" Value="-7"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.2" Value="-5.438"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.3" Value="-3.5"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.4" Value="-2.001"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.5" Value="0"/>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)" Storyboard.TargetName="Img2Bottom">
                <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="-24.75"/>
                <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="-22.5"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1" Value="-20.062"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.1" Value="-15.062"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.2" Value="-10"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.3" Value="-5.062"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.4" Value="-2.562"/>
                <EasingDoubleKeyFrame KeyTime="0:0:1.5" Value="0"/>
            </DoubleAnimationUsingKeyFrames>
            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="Img2Bottom">
                <DiscreteObjectKeyFrame KeyTime="0:0:0.8" Value="{x:Static Visibility.Visible}"/>
            </ObjectAnimationUsingKeyFrames>
        </Storyboard>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Image x:Name="Img2Top" Source="Images/02top.png" Grid.Row="1" Width="70" Height="50" RenderTransformOrigin="0.5,0.5" Margin="0,-1,0,0"/>
        <Image x:Name="Img1Top" Source="Images/01top.png" Grid.Row="1" Width="70" Height="50" RenderTransformOrigin="0.5,0.5" Margin="0,-1,0,0">
            <Image.RenderTransform>
                <TransformGroup>
                    <ScaleTransform/>
                    <SkewTransform/>
                    <RotateTransform/>
                    <TranslateTransform/>
                </TransformGroup>
            </Image.RenderTransform>
        </Image>
        <Image x:Name="Img2Bottom" Source="Images/02.png" Grid.Row="2" Width="70" Height="50" Visibility="Collapsed" RenderTransformOrigin="0.5,0.5">
            <Image.RenderTransform>
                <TransformGroup>
                    <ScaleTransform/>
                    <SkewTransform/>
                    <RotateTransform/>
                    <TranslateTransform/>
                </TransformGroup>
            </Image.RenderTransform>
        </Image>
        <Image x:Name="Img1Bottom" Source="Images/01.png" Grid.Row="2" Width="70" Height="50" RenderTransformOrigin="0.5,0.5"/>
        <Button Content="Next" HorizontalAlignment="Left" Margin="223.5,5,0,0" Grid.Row="3" VerticalAlignment="Top" Width="70" Click="Button_Click" />
    </Grid>
