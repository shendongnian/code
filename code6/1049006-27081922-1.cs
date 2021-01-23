    <Trigger Property="IsEnabled" Value="False">
       <Trigger.EnterActions>
          <BeginStoryboard Storyboard="{StaticResource onNotEnabled}"/>
       </Trigger.EnterActions>
       <Trigger.ExitActions>
          <BeginStoryboard Storyboard="{StaticResource onEnabled}"/>
       </Trigger.ExitActions>
    </Trigger>
