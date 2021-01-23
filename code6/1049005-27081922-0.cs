    <Trigger Property="IsEnabled" Value="False">
        <Trigger.EnterActions>
            <BeginStoryboard Storyboard="{StaticResource onNotEnabled}"/>
        </Trigger.EnterActions>
    </Trigger>
    <Trigger Property="IsEnabled" Value="True">
        <Trigger.EnterActions>
            <BeginStoryboard Storyboard="{StaticResource onEnabled}"/>
        </Trigger.EnterActions>
    </Trigger>
