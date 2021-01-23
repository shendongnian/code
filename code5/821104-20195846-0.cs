    <Rectangle Height="70" Fill="Green">
        <Rectangle.RenderTransform>
            <TransformGroup>
                <ScaleTransform ScaleX="0.2"/>
            </TransformGroup>
        </Rectangle.RenderTransform>
        <Rectangle.Triggers>
            <EventTrigger RoutedEvent="Rectangle.MouseLeftButtonDown">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="(FrameworkElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"  
                                            From="0.2"
                                            To="1"
                                            Duration="0:0:5"/>
                            <ColorAnimation
                            Storyboard.TargetProperty="Fill.Color"
                            To="Yellow"
                            BeginTime="0:0:5"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Rectangle.Triggers>
    </Rectangle>
