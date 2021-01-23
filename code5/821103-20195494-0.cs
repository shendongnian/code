    <Rectangle.Triggers>
        <EventTrigger RoutedEvent="Rectangle.MouseLeftButtonDown">
            <EventTrigger.Actions>
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Width" From="50" 
    To="{Binding ActualWidth, ElementName=ParentContainer}" Duration="0:0:5"/>
                        <ColorAnimation Storyboard.TargetProperty="Fill.Color" To="Yellow" 
    BeginTime="0:0:5"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger.Actions>
        </EventTrigger>
    </Rectangle.Triggers>
