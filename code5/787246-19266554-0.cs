    <Grid>
        <Grid.Background>
            <ImageBrush ImageSource="C:\Users\Public\Pictures\Sample Pictures\Desert.jpg"
                        Stretch="Fill" TileMode="Tile"
                        ViewportUnits="Absolute" Viewport="0,0,1024,768"/>
        </Grid.Background>
        <Grid.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <RectAnimation Storyboard.TargetProperty="Background.Viewport"
                                       To="-1024,0,1024,768" Duration="0:0:10" 
                                       RepeatBehavior="Forever"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Grid.Triggers>
    </Grid>
