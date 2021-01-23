    <ToolTip x:Key="ErrorToolTip" 
             Placement="Right" 
             Background="Red" 
             Foreground="White" 
             BorderThickness="0" 
             DataContext="{Binding Path=PlacementTarget, RelativeSource={RelativeSource Self}}">
        <ToolTip.Content>
            <Binding Path="(Validation.Errors)[0].ErrorContent"/>
        </ToolTip.Content>
        <ToolTip.Triggers>
            <EventTrigger RoutedEvent="ToolTip.Opened">
                <BeginStoryboard>
                    <Storyboard TargetProperty="HorizontalOffset">
                        <DoubleAnimation From="0" To="5" Duration="0:0:0.2" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </ToolTip.Triggers>
    </ToolTip>
