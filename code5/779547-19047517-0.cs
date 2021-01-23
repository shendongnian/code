    <Grid ...>
        <Grid.Resources>
            <Storyboard x:Name="MainImageSlideIn">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="MainImage">
                    <EasingDoubleKeyFrame KeyTime="0" Value="900"/>
                    <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="0" />
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Grid.Resources>
        <Image x:Name="MainImage"HorizontalAlignment="Left" VerticalAlignment="Top" Width="480" Source="/Assets/splash-bottom.png">
            <Image.RenderTransform>
                <CompositeTransform TranslateY="900" />
            </Image.RenderTransform>
        </Image>
    </Grid>
