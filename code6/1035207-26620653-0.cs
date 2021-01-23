    <StackPanel x:Name="pnlFlip" RenderTransformOrigin="0.5,0.5">           
        <StackPanel.RenderTransform>
            <RotateTransform />
        </StackPanel.RenderTransform>
        <Button Content="Test" Margin="200,78,197,-78" Name="btnTest" Height="30">
            <Button.Triggers>
                <EventTrigger RoutedEvent="Button.Click">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation To="180" Storyboard.TargetName="pnlFlip" Storyboard.TargetProperty="(UIElement.RenderTransform).(RotateTransform.Angle)"  />                               
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Button.Triggers>
        </Button>
        <Rectangle Margin="175,146,162,-239" Name="rectTest" Fill="Red" Height="127"/>
    </StackPanel>
