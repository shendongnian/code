    <Button>
        <Button.Template>
            <ControlTemplate TargetType="{x:Type Button}">
                <Path Name="Arrow" Data="M10,0 20,20 11,10 11,30 9,30 9,10 0,20Z" 
                    Fill="Black" HorizontalAlignment="Center" VerticalAlignment="Center" />
                <ControlTemplate.Triggers>
                    <EventTrigger RoutedEvent="Loaded">
                        <BeginStoryboard Name="FadeStoryboard">
                            <Storyboard RepeatBehavior="Forever">
                                <DoubleAnimation Storyboard.TargetName="Arrow" 
                                    Storyboard.TargetProperty="Opacity" From="0.5" To="1.0"
                                    Duration="0:0:0.3" AutoReverse="True" />
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="MouseEnter">
                        <PauseStoryboard BeginStoryboardName="FadeStoryboard" />
                    </EventTrigger>
                    <EventTrigger RoutedEvent="MouseLeave">
                        <ResumeStoryboard BeginStoryboardName="FadeStoryboard" />
                    </EventTrigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Button.Template>
    </Button>
