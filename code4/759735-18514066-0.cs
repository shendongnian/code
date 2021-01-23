    <Style TargetType="Grid" x:Key="AlertStyle">
        <Setter Property="Visibility" Value="Collapsed"/>
        <Style.Triggers>
            <Trigger Property="Visibility" Value="Visible">
                <Trigger.EnterActions>
                    <BeginStoryboard Name="Storyboard">
                        <Storyboard BeginTime="00:00:00">
                            <DoubleAnimation Storyboard.TargetProperty="Opacity" 
    Duration="00:00:02" To="1.0" />
                            <DoubleAnimation Storyboard.TargetProperty="Height" 
    Duration="00:00:01" To="60.0"/>
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
                <Trigger.ExitActions>
                    <StopStoryboard BeginStoryboardName="Storyboard" />
                </Trigger.ExitActions>
            </Trigger>
        </Style.Triggers>
    </Style>
