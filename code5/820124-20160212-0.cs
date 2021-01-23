    <Grid>
        <Grid.Background>
            <ImageBrush ImageSource="C:\Users\Public\Pictures\Sample Pictures\Koala.jpg"
                        Stretch="UniformToFill">
                <ImageBrush.Transform>
                    <RotateTransform/>
                </ImageBrush.Transform>
            </ImageBrush>
        </Grid.Background>
        <Grid.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation
                            Storyboard.TargetProperty="Background.Transform.Angle"
                            By="40" Duration="0:0:10"
                            AutoReverse="True" RepeatBehavior="Forever"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Grid.Triggers>
    </Grid>
