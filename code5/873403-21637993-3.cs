    <Button Content="MyButton">
        <Button.RenderTransform>
            <TranslateTransform x:Name="translate" X="-20" />
        </Button.RenderTransform>
        <Button.Triggers>
            <EventTrigger RoutedEvent="MouseEnter">
                <BeginStoryboard>
                    <Storyboard Duration="0:0:0.3">
                        <DoubleAnimation Storyboard.TargetName="translate" 
                                         Storyboard.TargetProperty="X"
                                         To="0">
                            <DoubleAnimation.EasingFunction>
                                <CubicEase />
                            </DoubleAnimation.EasingFunction>
                        </DoubleAnimation>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="MouseLeave">
                <BeginStoryboard>
                    <Storyboard Duration="0:0:0.3">
                        <DoubleAnimation Storyboard.TargetName="translate" 
                                         Storyboard.TargetProperty="X"
                                         To="-20">
                            <DoubleAnimation.EasingFunction>
                                <CubicEase />
                            </DoubleAnimation.EasingFunction>
                        </DoubleAnimation>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Button.Triggers>
    </Button>
