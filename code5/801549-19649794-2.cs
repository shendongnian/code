    <Trigger Property="IsChecked" Value="True">
    	<Setter Property="Content" Value="IS TRUE" />
    	<Trigger.EnterActions>
    		<BeginStoryboard Storyboard="{StaticResource ButtonDownTimeLine}"/>
    	</Trigger.EnterActions>
    	<Trigger.ExitActions>
    		<BeginStoryboard Storyboard="{StaticResource ButtonUpTimeLine}"/>
    	</Trigger.ExitActions>
    </Trigger>
    <Trigger Property="IsChecked" Value="False">
    	<Setter Property="Content" Value="IS FALSE"></Setter>
    </Trigger>
